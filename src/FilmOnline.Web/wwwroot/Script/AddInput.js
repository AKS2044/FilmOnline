var $addCountry = document.getElementsByClassName('add__input-country')[0];
var $addActor = document.getElementsByClassName('add__input-actor')[0];
var $addGenre = document.getElementsByClassName('add__input-genre')[0];
var $addManager = document.getElementsByClassName('add__input-manager')[0];

var $listCountry = document.getElementsByClassName('list-country')[0];
var $listActor = document.getElementsByClassName('list-actor')[0];
var $listGenre = document.getElementsByClassName('list-genre')[0];
var $listManager = document.getElementsByClassName('list-manager')[0];

$addCountry.addEventListener('click', function (event) {
    var $input = document.createElement('div');
    $input.classList.add('new-item');
    var inputCountry = '<input autofocus type="number" class="mine__input" data-val="true" data-val-required="The CountryIds field is required." id="CountryIds" name="CountryIds" value="">';

    $input.innerHTML = inputCountry;
    $listCountry.insertBefore($input, $addCountry);
});