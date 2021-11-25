// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your TypeScript code.
import "bootstrap"
import "jquery"
import "@fortawesome/fontawesome-free/js/all.js"
import "jquery-validation"
import "jquery-validation-unobtrusive"
import { Dashboard } from "./classes/Dashboard";

try {
    new Dashboard().init();
} catch (error) {   
}
