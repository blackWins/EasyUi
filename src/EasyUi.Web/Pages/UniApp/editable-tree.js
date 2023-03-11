var editabletree = {
    template: `
      <div class='tree'>
        <ul>
          <li v-for="(item,idx) in items" :key="item.id">
            <span>
              <i @click="switchChange(idx)" class="fa" :class="{'fa-angle-down':item.open,'fa-angle-right':!item.open}"></i>
              <span @click="toggle(idx)">{{ item.name }}</span>
              <i class="fa fa-trash-alt" @click="removeItem(idx)" v-show="item.id!=0"></i>
              <i class="fa fa-plus" @click="addItem(idx)" v-if="item.addable"></i>
            </span>
              <editable-tree @inner-click="innerClick" :level="level+1" :items="item.children" v-show="item.open"/>
          </li>
        </ul>
      </div>`,
    props: {
        items: {
            type: Array,
            default: () => []
        },
        level: {
            type: Number,
            default: 0
        }
    },
    data() {
        return {
        }
    },
    methods: {
        innerClick(e) {
            if (this.level == 0) {
                //console.log('item-click');
                this.$emit('item-click', e);
            }
            else {
                //console.log('inner-click');
                this.$emit('inner-click', e);
            }
        },
        switchChange(idx) {
            this.items[idx].open = !this.items[idx].open;
        },
        toggle(idx) {
            this.innerClick(this.items[idx]);
        },
        addItem(idx) {
            if (!vm.currentTagName) {
                return
            }
            newItem = {
                id: ++vm.pk_counter,
                parentId: this.items[idx].id,
                name: vm.currentTagName + (vm.pk_counter),
                content: vm.componentHtml,
                config: vm.getConfig(vm.properties),
                addable: vm.componentHtml.indexOf('/>') < 0,
                children: [],
                open: true
            }
            this.items[idx].children.push(newItem);
        },
        removeItem(idx) {
            this.items.splice(idx, 1);
        }
    }
}