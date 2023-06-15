define(['plugins/dialog', 'knockout'],
    function (dialog, ko, detailArray, addArray) {
        var vm = function (param) {
            var self = this;
            self.people = {
                FirstName: ko.observable(""),
                LastName: ko.observable(""),
                
            }
            self.people.FullName = ko.computed(() => self.people.FirstName() + " " + self.people.LastName())
            /*
             Yêu cầu:
             1. Đưa về UI về bảng.
             2. Thêm xóa sửa 1 object trong array
             */

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
