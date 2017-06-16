$(abonnement);

function abonnement() {
    $("select").change(function () {

        $("#miseajour").load("/catalogue/grille?categorie=" +
            $("#categorie").val() +
            "&subcategory=" +
            encodeURIComponent($("#subcategory").val()),
            abonnement
        );
    });
}