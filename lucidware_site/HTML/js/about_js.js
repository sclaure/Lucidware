//progress bar fade in
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= ($("#fade_check_9").offset().top)) {
	$('.fade_in_4').fadeTo(900,1);
}

});
