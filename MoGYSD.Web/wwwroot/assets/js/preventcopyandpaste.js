window.preventCopyPaste = function (inputId) {
    const el = document.getElementById(inputId);
  //  alert("preventCopyPaste called for:", inputId, "Element found:", !!el);
    if (el) {
        el.onpaste = e => e.preventDefault();
        el.oncopy = e => e.preventDefault();
        el.oncut = e => e.preventDefault();
    }
};

