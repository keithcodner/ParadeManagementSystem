$('#infoLabel').toggle(function () {
$('#infoLabel').text('SHOW INSTRUCTIONS AFTER PARADE IS RESET');
},function () {
$('#infoLabel').text('HIDE INSTRUCTIONS AFTER PARADE IS RESET');
});

$('#infoLabel').click(function () {
             $('#message').toggle();
         });
