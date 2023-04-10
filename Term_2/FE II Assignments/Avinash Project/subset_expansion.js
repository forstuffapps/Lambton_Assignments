// wait for the document to finish loading
$(document).ready(function() {

  // when a toggle button is clicked
  $('.toggle-btn').click(function(e) {

    // prevent the default behavior of the click event (i.e. following the link)
    e.preventDefault();

    // store a reference to the clicked toggle button
    var $this = $(this);

    // find the content that comes before the clicked toggle button
    var $content = $this.prev('.long-text');

    // if the content is currently hidden
    if ($content.hasClass('hide')) {

      // remove the 'hide' class and add the 'show' class to display the content
      $content.removeClass('hide').addClass('show');

      // update the text of the toggle button to indicate that clicking it will hide the content
      $this.text('Show Less');

    } else {

      // remove the 'show' class and add the 'hide' class to hide the content
      $content.removeClass('show').addClass('hide');

      // update the text of the toggle button to indicate that clicking it will show the content
      $this.text('Show More');
    }
  });
});



