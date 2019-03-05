<script>
    $( function()
    {
        $("#ask-btn").on('click', function () {

            var dataToSend = $("#ask-txt").val();
            var userid = $('#userid').val();
            $.ajax({
                type: "POST",
                url: "/User/QuestionBox",
                data: {question: JSON.stringify(dataToSend), userid : JSON.stringify(userid) },
                dataType: 'json',
                contentType: "application/json;charset=utf-8",
                success: function (response) {
                    if(response) { alert("It's alright."); }
                    else { console.log(response); }
                },
                error: function(response) {
                   console.log(response);
                }
            });
        });
    })
    </script>