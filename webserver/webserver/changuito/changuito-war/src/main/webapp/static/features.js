$( document ).ready(function() {

$("#conocenos").on("click", function(){ $("#featured-wrapper").load("/about") ;});
$("#linkdemo").on("click", function(){ $("#featured-wrapper").load("/demo") ;});

});