// This code sets up a slideshow with navigation buttons
$(document).ready(function() {
  // Initialize the slideIndex to 1 and show the first slide
  var slideIndex = 1;
  showSlides(slideIndex);

  // Bind click events to the prev and next buttons
  $(".prev").click(function() {
    plusSlides(-1);
  });

  $(".next").click(function() {
    plusSlides(1);
  });

  // Function to increment/decrement slideIndex by n and show the updated slide
  function plusSlides(n) {
    showSlides((slideIndex += n));
  }

  // Function to show the slide with index n and hide all others
  function showSlides(n) {
    var i;
    var slides = $(".mySlides");
    // If n is greater than the number of slides, reset slideIndex to 1
    if (n > slides.length) {
      slideIndex = 1;
    }
    // If n is less than 1, set slideIndex to the last slide
    if (n < 1) {
      slideIndex = slides.length;
    }
    // Hide all slides
    for (i = 0; i < slides.length; i++) {
      slides.eq(i).hide();
    }
    // Show the slide with index slideIndex-1 (since slideIndex starts at 1)
    slides.eq(slideIndex - 1).show();
  }
});
