
export default class PersonList extends React.Component {
    state = {
        people:[]
    }
    render() {
        return (
            <table className="table">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Name</th>
                        <th scope="col">City</th>
                        <th scope="col">Phone</th>
                    </tr>
                </thead>
                <tbody>
                {this.state.people.map(person => 
                        <tr>
                            <td>
                                {person.Id}
                            </td>
                            <td>
                                {person.Name}
                            </td>
                            <td>
                                {person.City.Name}
                            </td>
                            <td>
                                {person.PhoneNumber}
                            </td>
                        </tr>
                )}           
                </tbody>
            </table>
        )
    }
    
    componentDidMount() {
        axios.get("/React/People").then(res => {
            this.setState({people: res.data});
        }).catch(errors => 
        {
            console.error(errors);
        });
        console.log(this.state);
    }
    
}
