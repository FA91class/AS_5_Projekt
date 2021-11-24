"use strict";
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
Object.defineProperty(exports, "__esModule", { value: true });
// Write your TypeScript code.
require("bootstrap");
require("jquery");
require("jquery-validation");
require("jquery-validation-unobtrusive");
var Dashboard_1 = require("./classes/Dashboard");
try {
    new Dashboard_1.Dashboard().init();
}
catch (error) {
}
