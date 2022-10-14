(function ($) {
    function Product() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-product").on('show.bs.modal', function (e) {

                var button = $(e.relatedTarget);
                var url = button.attr("href");
                var modal = $(this);
                modal.find('.modal-content').html('Loading...');
                modal.find('.modal-content').load(url);

            }).on('hidden.bs.modal', function (e) {
                var modal = $(this);
                modal.removeData('bs.modal');
                modal.find('.modal-content').empty();
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new Product();
        self.init();
    })
}(jQuery))