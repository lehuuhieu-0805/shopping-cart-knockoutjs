define(['plugins/dialog', 'knockout'],
    function (dialog, ko) {
        var vm = function (params) {
            var self = this;
            self.product = {
                Id: ko.observable(params.Id),
                Name: ko.observable(params.Name),
                Price: ko.observable(params.Price),
                Quantity: ko.observable(params.Quantity),
                Category: ko.observable(params.Category ? params.Category : '')
            }
            this.categories = ko.observableArray();
            this.selectedCategory = ko.observable();
            this.activate = function () {
                self.get_categories()
                if (params.Category) {
                    this.selectedCategory = params.Category.Id
                }
            }
            this.attached = (view) => {
                self.view = view
            }
            this.cancel = () => {
                dialog.close(this, { status: false })
            }
            this.save = () => {
                this.product.CategoryId = this.selectedCategory
                dialog.close(this, {
                    status: true,
                    product: ko.toJSON(self.product)
                })
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
        }
        vm.show = function (obj) {
            return dialog.show(new vm(obj))
        }
        return vm;
    })