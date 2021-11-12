"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Dashboard = void 0;
var Dashboard = /** @class */ (function () {
    function Dashboard() {
        this._weekDashboardIdTrigger = "triggerWeekDashboard";
        this._dayDashboardIdTrigger = "triggerDayDashboard";
        this._weekDashboardId = "weekDashboard";
        this._dayDashboardId = "dayDashboard";
        this._hideWeek = "Wochen Übersicht verstecken";
        this._showWeek = "Wochen Übersicht anzeigen";
        this._hideDay = "Tages Übersicht verstecken";
        this._showDay = "Tages Übersicht anzeigen";
    }
    Dashboard.prototype.init = function () {
        var _this = this;
        var weekDashboard = document.getElementById(this._weekDashboardId);
        var dayDashboard = document.getElementById(this._dayDashboardId);
        var weekDashboardTrigger = document.getElementById(this._weekDashboardIdTrigger);
        var dayDashboardTrigger = document.getElementById(this._dayDashboardIdTrigger);
        weekDashboard.style.display = "none";
        weekDashboardTrigger.innerHTML = this._showWeek;
        weekDashboardTrigger.onclick = function () { _this.toggleWeekDashboard(); };
        dayDashboard.style.display = "block";
        dayDashboardTrigger.innerHTML = this._hideDay;
        dayDashboardTrigger.onclick = function () { _this.toggleDayDashboard(); };
    };
    Dashboard.prototype.toggleWeekDashboard = function () {
        var weekDashboard = document.getElementById(this._weekDashboardId);
        var weekDashboardTrigger = document.getElementById(this._weekDashboardIdTrigger);
        if (weekDashboard.style.display === "none") {
            weekDashboard.style.display = "block";
            weekDashboardTrigger.innerHTML = this._hideWeek;
        }
        else {
            weekDashboard.style.display = "none";
            weekDashboardTrigger.innerHTML = this._showWeek;
        }
    };
    Dashboard.prototype.toggleDayDashboard = function () {
        var dayDashboard = document.getElementById(this._dayDashboardId);
        var dayDashboardTrigger = document.getElementById(this._dayDashboardIdTrigger);
        if (dayDashboard.style.display === "none") {
            dayDashboard.style.display = "block";
            dayDashboardTrigger.innerHTML = this._hideDay;
        }
        else {
            dayDashboard.style.display = "none";
            dayDashboardTrigger.innerHTML = this._showDay;
        }
    };
    return Dashboard;
}());
exports.Dashboard = Dashboard;
