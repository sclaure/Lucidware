//block fade in and slide right
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= $("#fade_check_10").offset().top) {
	$('.details3').animate({
		opacity: '.7',
		'margin-right': '0px'
	});
}

});

//second block fade in and slide right
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= $("#fade_check_11").offset().top) {
	$('.details4').animate({
		opacity: '.7',
		'margin-right': '0px'
	});
}

});

//third block fade in and slide right
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= $("#fade_check_12").offset().top) {
	$('.details5').animate({
		opacity: '.7',
		'margin-right': '0px'
	});
}

});

//fourth block fade in and slide right
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= $("#fade_check_13").offset().top) {
	$('.details6').animate({
		opacity: '.7',
		'margin-right': '0px'
	});
}

});

//fifth block fade in and slide right
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= $("#fade_check_14").offset().top) {
	$('.details7').animate({
		opacity: '.7',
		'margin-right': '0px'
	});
}

});

//first pic fade in and slide left
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= ($("#fade_pic_1").offset().top)) {
	$('.side_photo3').animate({
		opacity: '1'
	}, 700);
}

});

//second pic fade in and slide left
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= ($("#fade_pic_2").offset().top)) {
	$('.side_photo4').animate({
		opacity: '1'
	}, 700);
}

});
//third pic fade in and slide left
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= ($("#fade_pic_3").offset().top)) {
	$('.side_photo5').animate({
		opacity: '1'
	}, 700);
}

});

//fourth pic fade in and slide left
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= ($("#fade_pic_4").offset().top)) {
	$('.side_photo6').animate({
		opacity: '1'
	}, 700);
}

});
