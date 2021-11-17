
const peopleListContainer = $("#people-list");
const personSearchInput = $("#ajax-person-search-input");
const personDeleteInput = $("#ajax-person-delete-input");

const baseUrl = "/Ajax/";

$("#ajax-person-delete-btn").click( (e) =>{
    e.preventDefault();
    DeletePerson(personDeleteInput.val())
    personDeleteInput.val("");
});

$("#ajax-person-search-btn").click( (e) =>{
    e.preventDefault();
    SearchPerson(personSearchInput.val())
    personSearchInput.val("");
});

// controller calls

function SearchPerson(search)
{
    if (search === undefined) return;
    $.post(`${baseUrl}Search`, {"SearchText":search} ,( htmlData ) => {
        peopleListContainer.html(htmlData);
    });
}

function GetPeople()
{
    $.get(`${baseUrl}GetPeopleList`,(htmlData ) => {
        peopleListContainer.html(htmlData);
    });
}



function DeletePerson(id)
{
    if (id === undefined) return;
    $.post(`${baseUrl}Delete`, {"id":id} ,() => {
        GetPeople();
    });
}