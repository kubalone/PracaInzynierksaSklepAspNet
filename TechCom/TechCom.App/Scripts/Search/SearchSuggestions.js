$(function () {

    var setupAutoComplete = function () {
        var $input = $(this);

        var options =
            {
                source: $input.attr("data-autocomplete-source"),
                select: function (event, ui) {
                    $input = $(this);
                    $input.val(ui.item.label);
                    var $form = $input.parents("form:first");
                    $form.submit();
                }
            };

        $input.autocomplete(options);
    };



    $("#SearchString").each(setupAutoComplete);

});