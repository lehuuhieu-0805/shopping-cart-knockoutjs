define(['plugins/dialog', 'knockout', './detailArray', './addArray'],
    function (dialog, ko, detailArray, addArray) {
        var vm = function (param) {
            var self = this;
            self.people = ko.observableArray([
                {
                    FirstName: ko.observable("Nguyễn"),
                    LastName: ko.observable("Văn A"),
                    FullName: ko.observable("Nguyễn Văn A"),
                },
                {
                    FirstName: ko.observable("Trần"),
                    LastName: ko.observable("Thị B"),
                    FullName: ko.observable("Trần Thị B"),
                },                
            ])

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
            // add
            this.add_customerarray = () => {
                addArray.show({
                    //FirstName: "",
                    //LastName: "",
                    //FullName: ""
                })
                    .then(response => {
                       
                        let cc = response.people;
                        let parsedData = JSON.parse(cc);

                        //console.log('test add', parsedData);
                        let firstName = parsedData.FirstName;
                        let lastName = parsedData.LastName;
                        let fullName = parsedData.FullName;
                        var obj53 = {
                            FirstName: ko.observable(firstName),
                            LastName: ko.observable(lastName),
                            FullName: ko.observable(fullName),
                        }                       
                        //console.log('check hiện tên', firstName);
                        self.people.push(obj53);
                    })
            }
            // edit_customer
            this.edit_customerArray = data => {
                //debugger
                detailArray.show(data)
                    .then(response => {
                        //console.log('test console',response)
                    })
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
