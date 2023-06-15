define(['plugins/dialog', 'knockout'],
    function (dialog, ko) {
        var vm = function (param) {
            var self = this;
             //param = {type: '', data}
            //self.people = {
            //    FirstName: ko.observable(param.FirstName),
            //    LastName: ko.observable(param.LastName),
            //    FullName: ko.observable(''),

            //}
            self.people = param;            
            self.people.FullName = ko.computed(() => param.FirstName() + " " + param.LastName())
            this.activate = () => {

            }
            this.attached = (view) => {
                self.view = view;
            }
            this.cancel = () => {
                dialog.close(this, { status: false });
            }
            this.save = () => {
                dialog.close(this, {
                    status: true,
                    people: ko.toJSON(self.people)
                });
            }
        };

        vm.show = function (obj) {
            return dialog.show(new vm(obj));
        };

        return vm;
    });