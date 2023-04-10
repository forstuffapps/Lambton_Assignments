$(document).ready(function(){
   $.getJSON("javascript_files/team.json", function(data){
     $.each(data.teammembers, function(key, value) {
       $("#team").append(
         '<div class="team-member">' +
           '<div class="name">' + value.name + '</div>' +
           '<div class="title">' + value.title + '</div>' +
           '<div class="bio">' + value.bio + '</div>' +
         '</div>'
       );
     });
   });
 });