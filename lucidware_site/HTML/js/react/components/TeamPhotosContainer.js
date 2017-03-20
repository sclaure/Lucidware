var MEMBER_ID_NAME_MAP = ["","jack","jake","paul","sergio","evans","david"];

var MEMBERS = {
  jack: {
    memberID: 1,
    fullName: "Jack Urbanek",
    workTitle: "Head of Software Engineering",
    image: "jack_img.png",
    bio: "Jack Urbanek is a junior in  Electrical and Computer Engineering at Carnegie Mellon University. From writing programs back in middle school to designing features at Facebook as an intern, he's made software a major part of his life. At Lucidware, Jack heads software development and leads research into the filter algorithms that keep Reach accurate."
  },
  jake: {
    memberID: 2,
    fullName: "Jake Tesler",
    workTitle: "Head of Electrical Engineering and Systems Design",
    image: "jake_photo2.jpg",
    bio: "Jake Tesler is an Electrical & Computer Engineer studying at Carnegie Mellon University. After discovering an affinity for electronics at a very young age, he founded his own local tech support company at the age of 9. Jake has a passion for design and hardware; after starting school, he quickly joined CMU’s Google Lunar X-Prize team, becoming a lead Avionics engineer for the team’s Lunar Rover. He is currently in charge of creating and building all electronic hardware for Lucidware."
  },
  paul: {
    memberID: 3,
    fullName: "Paul Ramirez",
    workTitle: "Head of Mechanical Engineering",
    image: "paul_img.png",
    bio: "Paul Ramirez is a Mechanical Engineering major in his junior year of college at Carnegie Mellon University. After founding his high school robotics team and becoming Lead of Mechanical design, he realized robotics and mechanical design were the things he wanted to work on for a career. As such, he loves using CAD to design parts as well as perform stress simulations. Designing the mechanical hardware for Lucidware has allowed him to continue learning more and more about designing efficient and practical products."
  },
  sergio: {
    memberID: 4,
    fullName: "Sergio Claure",
    workTitle: "Head of Website Development/Software Engineer",
    image: "sergio_photo.jpg",
    bio: "Majoring in Electrical and Computer Engineering, Sergio Claure is in his Junior year at Carnegie Mellon University. Coding at an early age, Sergio's passion lies within creating interesting software. Either working on websites or making virtual enviornments for Reach, Sergio's adaptability to any problem at hand are what allows him to grow more as a Software Engineer while accelerating Reach's development into the market."
  },
  evans: {
    memberID: 5,
    fullName: "Evans Hauser",
    workTitle: "Software Engineer",
    image: "evans_img.jpg",
    bio: "Evans Hauser is a Junior at Carnegie Mellon University. After developing virtual reality simulations in Unity for two summers at the psychological research lab, Eventlab, he became interested in developing new hardware to improve the VR experience. In line with his experience, he has joined the Lucidware team to develop virtual reality demos as a Software Engineer."
  },
  david: {
    memberID: 6,
    fullName: "David Selverian",
    workTitle: "Head of Business Development",
    image: "david_img_2.jpg",
    bio: "David Selverian is a Junior at Carnegie Mellon University. After previously starting and selling his own business, David joined the world of early stage, tech-focused venture capital, where he serves as an Analyst. He has extensive experience in operations and management, and as such, David heads business development for the Lucidware team."
  },
};

var TeamMember = React.createClass({
  clickHandler: function() {
    var member = MEMBERS[this.props.member];
    var newSelected = this.props.selected ? 0 : member.memberID;

    this.props.clickHandler(newSelected);
  },

  render: function() {
    var member = MEMBERS[this.props.member];
    var imgSource = "img/" + member.image;
    var memberClass = "react_team_member";
    var nameClass = "team_name";
    var jobClass = "team_job";
    if (this.props.selected) {
      memberClass = "react_team_member_selected";
      nameClass =  "team_name_selected";
      jobClass =  "team_job_selected";
    }

    return  <div className={memberClass} onClick={this.clickHandler}>
              <img src={imgSource} className="react_team_pic" alt="img/team_pic.jpg" title=""/>
              <h3 className={nameClass}>{member.fullName}</h3>
              <h4 className={jobClass}>{member.workTitle}</h4>
            </div>
  }
});

var BioRow = React.createClass({
  render: function() {
    var bioClass = "react_bio_row";
    if (this.props.expanded) {
      bioClass += " react_bio_row_expanded";
    }
    return <div className={bioClass}> 
      <div className="react_bio_container">
        {this.props.bio}
      </div>
    </div>;
  }

});

var TeamPhotosContainer = React.createClass({
  getInitialState: function() {
    return {selected: 0, bio1: "", bio2: ""};
  },

  updateSelected: function(newSelected) {
    var bio1 = this.state.bio1;
    var bio2 = this.state.bio2;
    if (newSelected > 0 && newSelected < 4) {
      bio1 = MEMBERS[MEMBER_ID_NAME_MAP[newSelected]].bio;
    }
    if (newSelected > 3) {
      bio2 = MEMBERS[MEMBER_ID_NAME_MAP[newSelected]].bio;
    }
    this.setState({selected: newSelected, bio1: bio1, bio2: bio2});
  },

  render: function() {
    var selected = this.state.selected;

    var bioRow1 = <BioRow bio={this.state.bio1} expanded={selected > 0 && selected < 4} />;
    var bioRow2 = <BioRow bio={this.state.bio2} expanded={selected > 3} />;
    return <div className="react_team_photo_container">
      <div className="react_team_photo_row">
        <TeamMember member="jack" clickHandler={this.updateSelected} selected={selected == 1}/>
        <TeamMember member="jake" clickHandler={this.updateSelected} selected={selected == 2}/>
        <TeamMember member="paul" clickHandler={this.updateSelected} selected={selected == 3}/>
      </div>
      {bioRow1}
      <div className="react_team_photo_row">
        <TeamMember member="sergio" clickHandler={this.updateSelected} selected={selected == 4}/>
        <TeamMember member="evans" clickHandler={this.updateSelected} selected={selected == 5}/>
        <TeamMember member="david" clickHandler={this.updateSelected} selected={selected == 6}/>
      </div>
      {bioRow2}
    </div>;
  }
});

React.render(
  <TeamPhotosContainer />,
  document.getElementById('teamPhotosContainer')
);