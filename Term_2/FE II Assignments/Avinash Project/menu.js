// This is a jQuery plugin that adds highlighting functionality to a menu.
(function ($) {
    // Define the plugin function
    $.fn.highlightMenu = function (options) {
        // Set the default options for the plugin
        var defaults = $.extend({
            'bgColor': '#32CD32',
            'color': '#ff1122',
            'hoverBgColor': '#cccccc',
            'hoverColor': '#000000',
            'linkWidth': '125px',
        }, options);
        
        // Loop through each item in the jQuery selection
        return this.each(function () {
            // Get all the menu items
            var items = $("li a");
            // Get the options for this particular menu
            var o = defaults;
            // Set the styles for each menu item
            items.css('font-family', 'arial, helvetica, sans-serif')
                 .css('font-weight', 'bold')
                 .css('text-decoration', 'none')
                 .css('background-color', o.bgColor)
                 .css('color', o.color)
                 .css('width', o.linkWidth);
            
            // Set up the hover styles for each menu item
            items.mouseover(function () {
                $(this).css('background-color', o.hoverBgColor)
                       .css('color', o.hoverColor);
            });
            items.mouseout(function () {
                $(this).css('background-color', o.bgColor)
                       .css('color', o.color);
            });
        });
    }
})(jQuery);
