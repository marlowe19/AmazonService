const data = [{
    name: "Incentro",
    instanceId: 54003,
    subtitle: "subtitle",
    isOnline: true,
    details: "time online is 4 hours"
}, {
    name: "DAF2",
    instanceId: 5400,
    subtitle: "subtitle",
    isOnline: false,
    details: "time online is 4 hours"
}, {
    name: "DAF3",
    instanceId: 5400,
    subtitle: "subtitle",
    isOnline: true,
    details: "time online is 4 hours"
}
]

const {
    Component
} = React.Component;
const {
    render
} = ReactDOM;
const App = () => {
    return (
        <div>
            <List />
        </div>
    )
}
function toggleInstanceState(action, instanceId) {
    $.post('https://jsonplaceholder.typicode.com/posts/', {
        action: action,
        instanceId: instanceId,
        data: data
    })
        .done(function (response, status) {
            console.log(response, status);
        })
        .fail(function (error) {
            console.log("error", error);
        });
    console.log("PostAction", action, instanceId)
}
const List = (props) => {
    const instances = data.map((value, key) => {
        const classes = value.isOnline ? "border-bar isOnline" : "border-bar";
        return (
            <div key={key} className="block">
                <div className="control-bar">
                    {value.isOnline ? <button onClick={() => { toggleInstanceState("stop", value.instanceId) }}>stop</button> : <button onClick={() => { toggleInstanceState("start", value.instanceId) }}>start</button>}

                </div>
                <div className="content">
                    <div className="name">
                        {value.name}
                    </div>
                    <div className="subtitle">
                        {value.subtitle}
                    </div>
                    <div className="details">
                        {value.details}
                    </div>
                </div>
                <div className={classes}></div>
            </div>
        )
    })
    return (<div className="list-container">{instances}</div>)
}

render(
    <App />, document.getElementById('app'));