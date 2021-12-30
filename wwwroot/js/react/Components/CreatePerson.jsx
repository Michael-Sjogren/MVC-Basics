function CreatePerson(props) {

    const [Name, setFullName] = React.useState("");
    const [PhoneNumber, setPhoneNumber] = React.useState("");
    const [Languages, setLanguages] = React.useState([]);
    const [CityId, setCity] = React.useState(-1);
    const [formErrors, setErrors] = React.useState([]);

    const onSubmit = (e) => {
        e.preventDefault();
        let errors = [];
        if (CityId === -1) {
            errors.push("City is not selected.");
        }
        if (Name.length <= 0) {
            errors.push("Name is not set");
        }
        if (PhoneNumber.length <= 0) {
            errors.push("Phone number is not set");
        }
        if (Languages.length <= 0) {
            errors.push("No languages was selected.");
        }
        if (errors.length > 0) {
            setErrors(errors);
            return;
        }
        setErrors([]);
        
        props.onCreatePerson(
            {
                Name: Name,
                PhoneNumber: PhoneNumber,
                Languages: Languages,
                CityId: CityId
            }
        );

        setFullName("");
        setPhoneNumber("");
        setLanguages([]);
        setCity(-1);
    }

    const handleLanguagesChanged = (options) => {
        setLanguages(Array.from(options).map((option) => option.value))
    }

    return (
        <>
            {(props.cities !== undefined && props.languages !== undefined) &&
                <form onSubmit={(event) => onSubmit(event)} className="border solid p-4">
                    <h4>Create a person</h4>
                    {formErrors.length > 0 &&

                        <div>
                            {
                                formErrors.map((err, indx) => <div key={"err" + indx}
                                                                   className="alert alert-danger">{err}</div>)
                            }
                        </div>
                    }
                    <div className="form-row">
                        <div className="form-group col-md-6">
                            <label htmlFor="inputName4">Full Name</label>
                            <input value={Name} onChange={(e) => setFullName(e.target.value)} type="text" className="form-control"
                                   id="inputName4" placeholder="Full Name"/>
                        </div>
                        <div className="form-group col-md-6">
                            <label htmlFor="inputPhoneNumber">Phone Number</label>
                            <input value={PhoneNumber} onChange={(e) => setPhoneNumber(e.target.value)} type="text" className="form-control"
                                   id="inputPhoneNumber" placeholder="Phone Number"/>
                        </div>
                    </div>

                    <div className="form-row">

                        <div className="form-group col-md-6">
                            <label htmlFor="inputCity">City</label>
                            <select onChange={(e) => setCity(e.target.value)} name="inputCity" id="inputCity"
                                    className="form-select">
                                {
                                    props.cities.map(city =>
                                        <option key={"city-id-" + city.Id} value={city.Id}>{city.Name}</option>)
                                }
                            </select>
                        </div>
                        <div className="input-group form-group col-md-4">
                            <label htmlFor="inputLanguages">Languages</label>
                            <select multiple value={Languages}
                                    onChange={(e) => handleLanguagesChanged(e.target.selectedOptions)}
                                    name="inputLanguages" id="inputLanguages" className="form-select">
                                {
                                    props.languages.map(lang =>
                                        <option key={"lang-opt-" + lang.Id} value={lang.Id}>{lang.Name}</option>)
                                }
                            </select>
                        </div>
                    </div>

                    <button type="submit" className="btn btn-primary">Create</button>
                </form>
            }
        </>
    )
}

export default CreatePerson;