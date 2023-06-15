define(['knockout'], function (ko) {
    var vm = function () {
        var self = this;
        this.cartItems = ko.observableArray();
        this.cart = ko.observable();
        this.activate = function () {
            self.get_cart_item_by_cart_id()
            self.get_cart()
        }
        this.attached = function (view) {
            self.view = view;
        }
        // get_cart_item_by_cart_id
        this.get_cart_item_by_cart_id = () => {
            $.ajax({
                url: '/CartItem/FindByCartId?id=1',
                async: false,
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    self.cartItems(response)
                }
            })
        }
        // get_cart
        this.get_cart = () => {
            $.ajax({
                url: '/Cart/GetCart?id=1',
                async: false,
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    self.cart(response)
                }
            })
        }
        // increase_product_quantity
        this.increase_product_quantity = (data) => {
            console.log(data)
            $.ajax({
                url: `/CartItem/IncreaseProductQuantity?productId=${data.ProductId}`,
                async: false,
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    self.get_cart()
                    self.get_cart_item_by_cart_id()
                    alert(response)
                }
            })
        }
        // minus_product_quantity
        this.minus_product_quantity = (data) => {
            console.log(data)
            $.ajax({
                url: `/CartItem/MinusProductQuantity?productId=${data.ProductId}`,
                async: false,
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    self.get_cart()
                    self.get_cart_item_by_cart_id()
                    alert(response)
                }
            })
        }
    }

    return vm;
})