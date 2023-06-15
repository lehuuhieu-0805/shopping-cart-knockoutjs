define(['knockout', './detail'], function (ko, detail) {
    var vm = function () {
        var self = this;
        this.categories = ko.observableArray();
        this.activate = function () {
            self.get_categories();
        }
        this.attached = function (view) {
            self.view = view;
        }
        // get_categories
        this.get_categories = () => {
            $.ajax({
                url: '/Category/GetCategories',
                async: false,
                type: 'GET',
                contentType: 'application/json, charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    self.categories(response)
                }
            })
        }
        // add_category
        this.add_category = () => {
            detail.show({
                Id: "",
                Name: ""
            }).then((response) => {
                if (response.status) {
                    $.ajax({
                        url: '/Category/InsertCategory',
                        data: response.category,
                        async: false,
                        type: 'POST',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (response) {
                            alert(response);
                            self.get_categories();
                        },
                        error: function (error) {
                            alert(error)
                        }
                    })
                }
            })
        }
        // update_category
        this.update_category = (data) => {
            detail.show(data).then((response) => {
                if (response.status) {
                    $.ajax({
                        url: '/Category/UpdateCategory',
                        data: response.category,
                        async: false,
                        type: 'POST',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (response) {
                            alert(response);
                            self.get_categories();
                        }
                    })
                }
            })
        }
        // delete_category
        this.delete_category = (data) => {
            $.ajax({
                url: `/Category/DeleteCategory?id=${data.Id}`,
                async: false,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    alert(response);
                    self.get_categories();
                },
                error: function (xhr) {
                    if (xhr.responseText.includes("Can't delete category")) {
                        alert("Can't delete category")
                    } else {
                        alert("Internal Server Error")
                    }
                }
            })
        }
    }

    return vm;
})