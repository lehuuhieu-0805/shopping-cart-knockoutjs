define(['plugins/dialog', 'knockout'],
    function (dialog, ko) {
        var vm = function (param) {
            var self = this;
            self.person = {
                FirstName: ko.observable(param.FirstName),
                LastName: ko.observable(param.LastName),
                FullName: ko.observable(''),

            }
            self.person.FullName = ko.computed(() => self.person.FirstName() + " " + self.person.LastName())
            //self.person.FullName = ko.computed(function () {
            //    return self.person.FirstName() + " " + self.person.LastName()
            //})
            
            //self.person.FirstName.subscribe(newValue => {
            //    self.person.FullName(`${self.person.FirstName()} ${self.person.LastName()}`)
            //})
            //self.person.FirstName.subscribe(function(newValue) {
            //    self.person.FullName(`${self.person.FirstName()} ${self.person.LastName()}`)
            //})
            //self.person.LastName.subscribe(newValue => {
            //    self.person.FullName(`${self.person.FirstName()} ${self.person.LastName()}`)
            //})
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
                });
            }
        };

        vm.show = function (obj) {
            return dialog.show(new vm(obj));
        };

        return vm;
    });