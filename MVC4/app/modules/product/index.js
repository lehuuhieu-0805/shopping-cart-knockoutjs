define(['knockout', './detail'],
    function (ko, detail) {
        function CartItem(Id, TotalQuantity, TotalPrice, Product) {
            this.Id = Id;
            this.TotalPrice = ko.observable(TotalPrice);
            this.TotalQuantity = ko.observable(TotalQuantity);
            this.Product = Product
        }
        function Cart(Id, TotalPrice, TotalQuantity) {
            this.Id = Id;
            this.TotalPrice = ko.observable(TotalPrice);
            this.TotalQuantity = ko.observable(TotalQuantity);
        }
        var vm = function () {
            var self = this;
            this.products = ko.observableArray([]);
            this.categories = ko.observableArray([]);
            this.selectedCategory = ko.observable([]);
            this.cart = ko.observable()
            this.cartItems = ko.observableArray([])
            this.totalPage = ko.observable()
            this.currentPage = ko.observable(1)
            this.searchValue = ko.observable()
            this.activate = function () {
                self.get_products();
                // paging
                paging_product(1, 5);
                self.get_categories();
                self.get_cart();
                const newCart = new Cart(Math.floor(Math.random() * 100), 0, 0);
                self.cart(newCart);
            }
            this.attached = function (view) {
                self.view = view;
            }
            // calling find_products_by_category_id when user select category
            this.selectedCategory.subscribe(function (newValue) {
                if (newValue == undefined) {
                    self.get_products()
                } else {
                    self.find_products_by_category_id(newValue)
                }
            })
            // paging
            this.paging = (page) => {
                if (self.searchValue()) {
                    pagingWithSearchValue(self.searchValue(), page)
                } else {
                    paging_product(page, 5)
                }
                self.currentPage(page)
            }
            function paging_product(page, pageSize){
                $.ajax({
                    url: `/Product/Paging?page=${page}&pageSize=${pageSize}`,
                    async: false,
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (responses) {
                        self.products(responses)
                    }
                });
            }
            // get_products
            this.get_products = () => {
                $.ajax({
                    url: '/Product/GetProducts',
                    async: false,
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (responses) {
                        self.totalPage(Math.ceil(responses.length / 5))
                    }
                });
            }
            // add_product
            this.add_product = () => {
                detail.show({
                    Id: "",
                    Name: "",
                    Price: "",
                    Quantity: ""
                }).then((response) => {
                    if (response.status) {
                        $.ajax({
                            url: '/Product/InsertProduct',
                            data: response.product,
                            async: false,
                            type: 'POST',
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            success: function (response) {
                                alert(response);
                                self.get_products();
                            }
                        })
                    }
                })
            }
            // update_product
            this.update_product = (data) => {
                detail.show(data).then((response) => {
                    if (response.status) {
                        $.ajax({
                            url: '/Product/UpdateProduct',
                            data: response.product,
                            async: false,
                            type: 'POST',
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            success: function (response) {
                                alert(response);
                                self.get_products();
                            }
                        });
                    }
                });
            }
            // delete_product
            this.delete_product = (data) => {
                $.ajax({
                    url: `/Product/DeleteProduct?id=${data.Id}`,
                    async: false,
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        alert(response);
                        self.get_products();
                    }
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
            // find_products_by_category_id
            this.find_products_by_category_id = (id) => {
                $.ajax({
                    url: `/Product/FindByCategoryId?Id=${id}`,
                    async: false,
                    type: 'GET',
                    contentType: 'application/json, charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        self.products(response)
                    }
                })
            }
            // get_cart
            this.get_cart = () => {
                $.ajax({
                    url: '/Cart/GetCart?id=1',
                    aysnc: false,
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        //self.cart(response);
                    }
                })
            }
            // add_to_cart
            /*this.add_to_cart = (data) => {
                console.log(data)
                const cartItem = {
                    CartId: 1,
                    ProductId: data.Id,
                    ProductQuantity: 1,
                    TotalPrice: data.Price
                };
                $.ajax({
                    url: '/CartItem/AddToCart',
                    data: JSON.stringify(cartItem),
                    async: false,
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        console.log(response)
                        alert(response)
                    }
                })
            }*/
            // minus_product_quantity
            this.minus_product_quantity = (data) => {
                add_to_cart(data.Product, -1, -data.Product.Price)

            }
            // increase_product_quantity
            this.increase_product_quantity = (data) => {
                add_to_cart(data.Product, 1, data.Product.Price)

            }
            // add_to_cart
            this.add_to_cart = (data) => {
                add_to_cart(data, 1, data.Price)
            }
            function add_to_cart(data, quantity, price) {
                if (quantity > data.Quantity) {
                    return alert("Quantity of product in stock not enough")
                }
                const existingCartItem = ko.utils.arrayFirst(self.cartItems(), (item) => {
                    return item.Product.Id === data.Id;
                })
                if (existingCartItem) {
                    if (existingCartItem.TotalQuantity() + quantity > data.Quantity) {
                        return alert("Quantity of product in stock not enough")
                    }
                    existingCartItem.TotalQuantity(existingCartItem.TotalQuantity() + quantity)
                    existingCartItem.TotalPrice(existingCartItem.TotalPrice() + price)
                    if (existingCartItem.TotalQuantity() <= 0) {
                        self.cartItems.remove(existingCartItem)
                    }
                    const cart = self.cart()
                    cart.TotalPrice(cart.TotalPrice() + price);
                    cart.TotalQuantity(cart.TotalQuantity() + quantity);
                } else {
                    const newCartItem = new CartItem(Math.floor(Math.random() * 100), 1, data.Price, data);
                    self.cartItems.push(newCartItem)
                    const cart = self.cart()
                    cart.TotalPrice(cart.TotalPrice() + data.Price);
                    cart.TotalQuantity(cart.TotalQuantity() + 1);
                }
            }
            this.search_by_name = () => {
                if (self.searchValue() === undefined || self.searchValue() === null) {
                    self.searchValue('')
                }
                $.ajax({
                    url: `/Product/SearchByName?name=${self.searchValue()}`,
                    async: false,
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (responses) {
                        self.totalPage(Math.ceil(responses.length / 5))
                        self.currentPage(1)
                        pagingWithSearchValue(self.searchValue(), self.currentPage())
                    }
                })
            }
            function pagingWithSearchValue(searchValue, currentPage) {
                $.ajax({
                    url: `/Product/SearchByNameWithPaging?name=${searchValue}&page=${currentPage}&pageSize=5`,
                    async: false,
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (responses) {
                        self.products(responses)
                    }
                })
            }
        }

        return vm;
    });