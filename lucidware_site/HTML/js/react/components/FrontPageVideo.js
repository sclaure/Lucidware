var FrontPageVideo = React.createClass({
	render: function (){
		return React.createElement("embed", { src: this.state.streamUrl,
      		type: "video/quicktime",
      		autoPlay: true,
      		"data-qtsrc": this.state.streamUrl,
      		target: "myself",
      		"scale": "tofit",
      		"data-controller": false,
      		"data-pluginspage": "http://www.apple.com/quicktime/download/",
     	 	loop: "false" }, this.props);
	}
});

React.render(
	<FrontPageVideo />,
	document.GetElementById('frontPageVideo')
);