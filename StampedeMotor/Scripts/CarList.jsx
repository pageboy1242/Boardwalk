var Car = React.createClass({
	render: function () {
		return (
			<div className="car">
				<p className="carDescription">
					{this.props.description}
				</p>
			</div>
		);
	}
});

var CarsList = React.createClass({
	render: function () {
		var carNodes = this.props.data.map(function(Car) {
			return (
				<Car description={Car.Description} key={Car.Id}>
				</Car>
			);
		});
		return (
			<div className="car">
				{carNodes}	
			</div>
		);
	}
});

ReactDOM.render(
	<CarsList url="/CarList" />,
	document.getElementById('content')
);