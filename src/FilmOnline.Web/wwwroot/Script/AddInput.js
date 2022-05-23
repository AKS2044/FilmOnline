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

$addActor.addEventListener('click', function (event) {
    var $input = document.createElement('div');
    $input.classList.add('new-item');
    var inputActor = '<input autofocus type="number" class="mine__input" data-val="true" data-val-required="The ActorIds field is required." id="ActorIds" name="ActorIds" value="">';

    $input.innerHTML = inputActor;
    $listActor.insertBefore($input, $addActor);
});

$addGenre.addEventListener('click', function (event) {
    var $input = document.createElement('div');
    $input.classList.add('new-item');
    var inputGenre = '<input autofocus type="number" class="mine__input" data-val="true" data-val-required="The GenreIds field is required." id="GenreIds" name="GenreIds" value="">';

    $input.innerHTML = inputGenre;
    $listGenre.insertBefore($input, $addGenre);
});

$addManager.addEventListener('click', function (event) {
    var $input = document.createElement('div');
    $input.classList.add('new-item');
    var inputManager = '<input autofocus type="number" class="mine__input" data-val="true" data-val-required="The StageManagerIds field is required." id="StageManagerIds" name="StageManagerIds" value="">';

    $input.innerHTML = inputManager;
    $listManager.insertBefore($input, $addManager);
});