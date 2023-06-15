define(['plugins/dialog', 'knockout'], function (dialog, ko) {
    var vm = function (params) {
        var self = this;
        self.category = {
            Id: ko.observable(params.Id),
            Name: ko.observable(params.Name)
        }
        this.activate = () => {

        }
        this.attached = (view) => {
            self.view = view
        }
        this.cancel = () => {
            dialog.close(this, { status: false })
        }
        this.save = () => {
            dialog.close(this, {
                status: true,
                category: ko.toJSON(self.category)
            })
        }
    }
    vm.show = function (obj) {
        return dialog.show(new vm(obj))
    }
    return vm
})