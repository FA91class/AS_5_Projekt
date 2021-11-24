"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Dashboard = void 0;
class Dashboard {
    _weekDashboardIdTrigger = "triggerWeekDashboard";
    _dayDashboardIdTrigger = "triggerDayDashboard";
    _weekDashboardId = "weekDashboard";
    _dayDashboardId = "dayDashboard";
    _hideWeek = "Wochen Übersicht verstecken";
    _showWeek = "Wochen Übersicht anzeigen";
    _hideDay = "Tages Übersicht verstecken";
    _showDay = "Tages Übersicht anzeigen";
    init() {
        let weekDashboard = document.getElementById(this._weekDashboardId);
        let dayDashboard = document.getElementById(this._dayDashboardId);
        let weekDashboardTrigger = document.getElementById(this._weekDashboardIdTrigger);
        let dayDashboardTrigger = document.getElementById(this._dayDashboardIdTrigger);
        weekDashboard.style.display = "none";
        weekDashboardTrigger.innerHTML = this._showWeek;
        weekDashboardTrigger.onclick = () => { this.toggleWeekDashboard(); };
        dayDashboard.style.display = "block";
        dayDashboardTrigger.innerHTML = this._hideDay;
        dayDashboardTrigger.onclick = () => { this.toggleDayDashboard(); };
        console.log("Dashboard initialized");
    }
    toggleWeekDashboard() {
        let weekDashboard = document.getElementById(this._weekDashboardId);
        let weekDashboardTrigger = document.getElementById(this._weekDashboardIdTrigger);
        if (weekDashboard.style.display === "none") {
            weekDashboard.style.display = "block";
            weekDashboardTrigger.innerHTML = this._hideWeek;
        }
        else {
            weekDashboard.style.display = "none";
            weekDashboardTrigger.innerHTML = this._showWeek;
        }
    }
    toggleDayDashboard() {
        let dayDashboard = document.getElementById(this._dayDashboardId);
        let dayDashboardTrigger = document.getElementById(this._dayDashboardIdTrigger);
        if (dayDashboard.style.display === "none") {
            dayDashboard.style.display = "block";
            dayDashboardTrigger.innerHTML = this._hideDay;
        }
        else {
            dayDashboard.style.display = "none";
            dayDashboardTrigger.innerHTML = this._showDay;
        }
    }
}
exports.Dashboard = Dashboard;
