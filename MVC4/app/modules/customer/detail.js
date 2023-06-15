define(['plugins/dialog', 'knockout'],
    function (dialog, ko) {
        var vm = function (param) {
            var self = this;
            self.customer = {
                FirstName: ko.observable(param.FirstName),
                LastName: ko.observable(param.LastName),
                City: ko.observable(param.City),
                Country: ko.observable(param.Country),
                Phone: ko.observable(param.Phone),
                Id: ko.observable(param.Id),
            }
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
                    customer: ko.toJSON(self.customer)
                });
            }
        };

        vm.show = function (obj) {
            return dialog.show(new vm(obj));
        };

        return vm;
    });