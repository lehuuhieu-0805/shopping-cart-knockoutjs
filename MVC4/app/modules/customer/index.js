define(['knockout', './detail'],
    function (ko, detail) {
        var vm = function () {
            var self = this;
            this.customers = ko.observableArray();
            this.activate = function () {
                self.get_customers();
            }
            this.attached = function (view) {
                self.view = view;
                              
            }
            // get_customers
            this.get_customers = () => {
                $.ajax({
                    url: '/Customer/GetCustomers',
                    async: false,
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        self.customers(response);
                    }
                });
            }
            // add_customer
            this.add_customer = () => {
                detail.show({
                    FirstName: "",
                    LastName: "",
                    City: "",
                    Country: "",
                    Phone: "",
                    Id: ""
                }).then(response => {
                    if (response.status) {
                        $.ajax({
                            url: '/Customer/InsertCustomer',
                            data: response.customer,
                            async: false,
                            type: 'POST',
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            success: function (response) {
                                alert(response);
                                self.get_customers();
                            }
                        });
                    }
                });
            }
            // edit_customer
            this.edit_customer = data => {
                detail.show(data).then(response => {
                    if (response.status) {
                        $.ajax({
                            url: '/Customer/UpdateCustomer',
                            data: response.customer,
                            async: false,
                            type: 'POST',
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            success: function (response) {
                                alert(response);
                                self.get_customers();
                            }
                        });
                    }
                });
            }
            // delete_customer
            this.delete_customer = data => {
                $.ajax({
                    url: `/Customer/DeleteCustomer?id=${data.Id}`,
                    async: false,
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        alert(response);
                        self.get_customers();
                    }
                });
            }
        }
        return vm;
    });