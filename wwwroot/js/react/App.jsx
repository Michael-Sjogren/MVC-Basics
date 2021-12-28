import PersonList from './Components/PersonList.jsx';
class App extends React.Component {
    render() {
        return (
            <div className="container">
                Hello from react!
                <PersonList/>
            </div>
        )
    }
}

ReactDOM.render(<App/>, document.getElementById("react-app"));