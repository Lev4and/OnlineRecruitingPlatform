(function() {
  "use strict";
  window.onload = function() {
    var form = document.getElementById("form1");

    var pristine = new Pristine(
      form,
      {
        classTo: "form-group",
        errorClass: "has-danger",
        successClass: "has-success",
        errorTextParent: "form-group",
        errorTextTag: "div",
        errorTextClass: "invalid-feedback"
      },
      true
    );

    form.addEventListener("submit", function(e) {
      e.preventDefault();
      var valid = pristine.validate();

      if (!valid) form.classList.add("was-validated");
      else form.classList.remove("was-validated");
    });
  };
})();
