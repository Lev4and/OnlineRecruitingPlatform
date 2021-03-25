(function() {
  "use strict";
  var Delta = Quill.import("delta");
  var quill = new Quill("#editor-container", {
    modules: {
      toolbar: true
    },
    placeholder: "Compose an epic...",
    theme: "snow"
  });

  // Store accumulated changes
  var change = new Delta();
  quill.on("text-change", function(delta) {
    change = change.compose(delta);
  });

  // Save periodically
  setInterval(function() {
    if (change.length() > 0) {
      console.log("Saving changes", change);
      change = new Delta();
    }
  }, 5 * 1000);

  // Check for unsaved data
  window.onbeforeunload = function() {
    if (change.length() > 0) {
      return "There are unsaved changes. Are you sure you want to leave?";
    }
  };
})();
