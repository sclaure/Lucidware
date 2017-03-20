// left: 37, up: 38, right: 39, down: 40,
// spacebar: 32, pageup: 33, pagedown: 34, end: 35, home: 36
var keys = {37: 1, 38: 1, 39: 1, 40: 1};

function preventDefault(e) {
  e = e || window.event;
  if (e.preventDefault)
      e.preventDefault();
  e.returnValue = false;  
}

function preventDefaultForScrollKeys(e) {
    if (keys[e.keyCode]) {
        preventDefault(e);
        return false;
    }
}

function disableScroll() {
  if (window.addEventListener) // older FF
      window.addEventListener('DOMMouseScroll', preventDefault, false);
  window.onwheel = preventDefault; // modern standard
  window.onmousewheel = document.onmousewheel = preventDefault; // older browsers, IE
  window.ontouchmove  = preventDefault; // mobile
  document.onkeydown  = preventDefaultForScrollKeys;
}

function enableScroll() {
    if (window.removeEventListener)
        window.removeEventListener('DOMMouseScroll', preventDefault, false);
    window.onmousewheel = document.onmousewheel = null; 
    window.onwheel = null; 
    window.ontouchmove = null;  
    document.onkeydown = null;  
}


//this is to disable scrolling during animation



var timer = true;

var Heading = React.createClass({

	//var timer = true;

	scrolling: function(index){
		//this will play through all five animations, not what we want!!
		var scrollPos = ["#top_marker", "#uniqueness_marker", "#use_marker", '#team_marker', "#contact_marker"];
		if (timer){
			timer = false;
			disableScroll();
			setTimeout(function(){
				timer = true;
				enableScroll();
				}, 900);
			$('html,body').animate({
    			scrollTop: $(scrollPos[index]).offset().top
    		}, 800); 
		}
		
	},

	render: function() {
		return (
			<div className="heading">
				<div className="heading_menu">
					<div className="logo_hand">	
						<img src="img/lucidware_logo.png"/>
					</div>
					
					<nav>
						<ul>
							<li onClick={this.scrolling.bind(this, 0)}>Home</li>
							<li onClick={this.scrolling.bind(this, 1)}>Work</li>
							<li onClick={this.scrolling.bind(this, 2)}>Use Cases</li>
							<li onClick={this.scrolling.bind(this, 3)}>About Us</li>
							<li onClick={this.scrolling.bind(this, 4)}>Contact</li>
						</ul>
					</nav>
				</div>
			</div>
		);
	}
});

React.render(
	<Heading />,
	document.getElementById('heading')
);