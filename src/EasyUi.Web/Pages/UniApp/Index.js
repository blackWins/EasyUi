var vm;
var l = abp.localization.getResource('EasyUi');
$(function () {

    var model = {
        fullscreen: false,
        currentTagName: '',
        componentList: [],
        properties: [],
        template: '',
        pk_counter: 0,
        doms: [],
        items: [{ id: 0, parentId: 0, name: 'tepmlate', children: [], open: true, addable: true }]
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
                const reg = /<\/?[^>]*>/g;
                const arr = this.template.match(reg);
                console.log(arr);
                var config = this.getConfig(this.properties);
                //console.log('componentHtml' + new Date())
                if (config.attributes) {
                    var endBlock = this.template.match(/(\/?)>/)[0];//support end tag of '>' or '/>' 
                    return this.template.replace(endBlock, ' ' + config.attributes + endBlock);
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

                //console.log(result);
                var output = `
<template>
	<view class="container">${h}
	</view>
</template>

<script>
    export default {
        components: {},
        data() {
            return {
            ${[...new Set(m)].join(',\n')}
            };
        },
        method: {
            ${[...new Set(f)].join(',\n')}
        }
    };
</script>

<style>
</style>`;
                return output;
            }
        },
        methods: {
            getConfig(properties) {
                var attributes = [];
                var bindModel = [];
                var func = [];
                for (var i in properties) {
                    if (!properties[i].value) {
                        continue;
                    }
                    properties[i].value = properties[i].value.replace(/"/g, "'");
                    //try match @myFunc(param) or myFunc(param)
                    var funclist = properties[i].value.match(/[@a-zA-Z_][a-zA-Z0-9_]*\(.*?\)/g);
                    if (properties[i].type == 5) {//5:typeof function
                        var funcName = properties[i].value.match(/[a-zA-Z_][a-zA-Z0-9_]*/);
                        var param = properties[i].value.match(/\((.*?)\)/);
                        func.push(funcName + '(' + (param == null ? '' : param[1].split(',').map(function (item, idx) { return 'p' + idx }).join(',')) + '){}');
                        attributes.push(`@click="${properties[i].value.replace('@', '')}"`);
                    }
                    else if (funclist) {
                        attributes.push(`:${properties[i].name}="${properties[i].value.replace('@', '')}"`);
                        for (var fi in funclist) {
                            var funcName = funclist[fi].match(/[a-zA-Z_][a-zA-Z0-9_]*/);
                            var param = funclist[fi].match(/\((.*?)\)/)[1];
                            func.push(funcName + '(' + (param == '' ? '' : param.split(',').map(function (item, idx) { return 'p' + idx }).join(',')) + '){}');
                        }
                    }
                    else if (properties[i].value.indexOf('@') == 0) {
                        attributes.push(':' + properties[i].name + '="' + (properties[i].value.substr(1)) + '"');
                        // filter like :class={'hidden':ishidden}
                        if (!properties[i].value.match(/[:\+={}]/)) {
                            bindModel.push(properties[i].value.substr(1) + ':""');
                        }
                    }
                    else {
                        attributes.push(`${properties[i].name}="${properties[i].value}"`);
                    }
                }
                //console.log(func);
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
                    //console.log(f);
                    //debugger
                    return {
                        model: item.config.model.concat(m),
                        func: item.config.func.concat(f),
                        html: `\n${tab}` + item.content.replace('><', `>${h}\n${tab}<`)
                    };
                }
                else {

                    return {
                        model: item.config.model,
                        func: item.config.func,
                        html: '\n' + tab + item.content
                    };
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
                            properties[i].value = null;[i].defaultValue;
                        }
                        that.properties = properties.concat(defaultFunc);
                    });
            },
            printDom() {
                easyUi.uniApp.uni.getTageOutput(item)
                    .done(function (result) {
                        console.log(result);
                    });
            },
            copy(type) {
                const text = type == 'all' ? this.pageHtml : this.componentHtml;
                navigator.clipboard.writeText(text);
                alert(l('Copied'))

            },
            getTypeName(type) {
                switch (type) {
                    case 0: return 'String';
                    case 1: return 'Boolean';
                    case 2: return 'Numbuer';
                    case 3: return 'Object';
                    case 4: return 'Array';
                    case 5: return 'Function';
                    default: return '';
                }
            }
        }
    })
});
