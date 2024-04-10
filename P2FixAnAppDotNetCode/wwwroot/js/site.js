// Write your JavaScript code.

// Redirect to index product after order completed with delay
function redirectToHomeAfterDelay() {
    setTimeout(function () {
        window.location.href = productUrl;
    }, 5000);
}
