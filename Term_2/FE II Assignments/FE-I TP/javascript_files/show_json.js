$(document).ready(function(){
   //$.getJSON("javascript_files/team.json", function(data){
    $.getJSON("https://cc1-s3-bucket-1.s3.us-east-2.amazonaws.com/team.json", function(data){
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