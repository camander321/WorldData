$(document).ready(function() {

  $(".searchOption").change(function(){
    $(".searchBar").remove();

    if($(this).val() === "all")
    {
      $('#formId').attr('action', '/');
    }
    else if($(this).val() === "name")
    {
      $('#formId').attr('action', '/name');
      $('#inputs').append('<input class="searchBar form-control" name="input1" placeholder="Enter country name" type="text">');
    }
    else if($(this).val() === "continent")
    {
      $('#formId').attr('action', '/continent');
      $('#inputs').append('<input class="searchBar form-control" name="input1" placeholder="Enter continent" type="text">');
    }
    else if($(this).val() === "pop")
    {
      $('#formId').attr('action', '/pop');
      $('#inputs').append('<input class="searchBar form-control" name="input1" placeholder="Enter Min Population" type="number">');
      $('#inputs').append('<input class="searchBar form-control" name="input2" placeholder="Enter Max Population" type="number">');
    }
  });
});
