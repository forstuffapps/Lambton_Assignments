$(document).ready(function(){
   $.getJSON("js_files/AD_team.json", function(data){
     $.each(data.ADteammembers, function(key, value) {
       $("#AD_team").append(
         '<div class="ad-team-member">' +
           '<div class="name">' + value.name + '</div>' +
           '<div class="title">' + value.title + '</div>' +
           '<div class="bio">' + value.bio + '</div>' +
         '</div>'
       );
     });
   });
 });