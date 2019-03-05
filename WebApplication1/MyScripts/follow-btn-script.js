$('#follow-btn').click(function() {
        $.ajax({
            type: "POST",
            url: "/SomebodysPage/Follow",
            data: {
            userid: "3",
            id: "1",
          },
            success: function() {
            alert("tamam");
        }

        })
  $(this).text(function(_, text) {
    return text === "Follow" ? "Unfollow" : "Follow";
  });
  if($(this).text() == "Follow") {
    $(this).removeClass('unfollow');
  } else if($(this).text() == "Unfollow") {
    $(this).addClass('unfollow');
  }
});