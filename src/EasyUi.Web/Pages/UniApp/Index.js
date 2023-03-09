var vm;
$(function () {
    var l = abp.localization.getResource('BookStore');

    var model = {
        currentTagName: '',
        componentList: [],
        properties: [],
        template: '',
        pk_counter: 0,
        doms: [],
        items: [{ id: 0, parentId: 0, name: 'tepmlate', children: [], open: true }]
    }

    var defaultFunc = [{
        "name": "@click",
        "type": 5,
        "defaultValue": "",
        "description": "监听 DOM 事件，并在事件触发时执行对应的 JavaScript",
        "value": ""
    }
    ]

    Vue.component('editable-tree', editabletree);
    vm = new Vue({
        el: '#main',
        data: model,
        created() {
            this.getComponentList();
        },
        computed: {
            componentHtml() {
                var config = this.getConfig();
                console.log('componentHtml' + new Date())
                if (config.attributes) {
                    return this.template.replace('>', ' ' + config.attributes + '>');
                }
                else {
                    return this.template;
                }
            },
            pageHtml() {
                var result = [];

                for (var i in this.items[0].children) {
                    result.push(this.getChildContent(this.items[0].children[i], 1));
                }

                var m = [], f = [], h = '';
                for (let c in result) {
                    m = m.concat(result[c].model);
                    f = f.concat(result[c].func);
                    h += result[c].html || '';
                }

                console.log(result);
                var output = `
<template>
    <view class="container">`+ h + `
    </view>
</template>

<script>
    export default {
        components: {},
        data() {
            return {
            `+ ([...new Set(m)].join(',\r\n')) + `
            };
        },
        method: {
            `+ ([...new Set(f)].join(',\r\n')) + `
        }
    };
</script>

<style>
</style>`;
                return output;
            }
        },
        methods: {
            getConfig() {
                var attributes = [];
                var bindModel = [];
                var func = [];
                for (var i in this.properties) {
                    if (this.properties[i].value == this.properties[i].defaultValue) {
                        continue;
                    }
                    if (this.properties[i].type == 5) {
                        var name = this.properties[i].value.replace('@', '');
                        func.push(name + '(){}');
                        attributes.push('@click="' + name + '"');
                    }
                    else if (this.properties[i].value.indexOf('@') == 0) {
                        attributes.push(':' + this.properties[i].name + '="' + (this.properties[i].value.substr(1)) + '"');
                        bindModel.push(this.properties[i].value.substr(1) + ':""');
                    }
                    else {
                        attributes.push(this.properties[i].name + '="' + this.properties[i].value + '"');
                    }
                }
                console.log(func);
                return {
                    attributes: attributes.join(' '),
                    model: bindModel,
                    func: func
                }
            },
            getChildContent(item, tabCount) {
                var nodes = [];
                var tab = this.setTab(tabCount);
                if (item.children.length > 0) {
                    for (let c in item.children) {
                        nodes.push(this.getChildContent(item.children[c], tabCount + 1));
                    }

                    var m = [], f = [], h = '';
                    for (let c in nodes) {
                        m = m.concat(nodes[c].model);
                        f = f.concat(nodes[c].func);
                        h += nodes[c].html || '';
                    }
                    console.log(func);
                    //debugger
                    return {
                        model: item.config.model.concat(m),
                        func: item.config.func.concat(f),
                        html: '\r\n' + tab + item.content.replace('><', '>' + h + '\r\n' + tab + '<')
                    };

                    return '\r\n' + tab + item.content.replace('><', '>' + nodes.join('') + '\r\n' + tab + '<');
                }
                else {

                    return {
                        model: item.config.model,
                        func: item.config.func,
                        html: '\r\n' + tab + item.content
                    };

                    return '\r\n' + tab + item.content;
                }
            },
            setTab(count) {
                var t = '';
                for (var i = 0; i < count; i++) {
                    t += '\t';
                }
                return t;
            },
            treeClick(e) {
                console.log(e);
            },
            getComponentList() {
                var that = this;
                easyUi.components.tags.getList({ name: null })
                    .done(function (result) {
                        that.componentList = result.items;
                    });
            },
            getComponent(idx) {
                var item = this.componentList[idx];
                this.currentTagName = item.name;
                this.template = item.code
                var that = this;
                easyUi.components.tagAttribute.getList({ tagId: item.id })
                    .done(function (result) {
                        var properties = result.items;
                        for (var i in properties) {
                            properties[i].value = properties[i].defaultValue;
                        }
                        that.properties = properties.concat(defaultFunc);
                    });
            },
            printDom() {
                easyUi.uniApp.uni.getTageOutput(item)
                    .done(function (result) {
                        console.log(result);
                    });
            }
        }
    })
});
