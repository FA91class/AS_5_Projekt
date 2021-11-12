export class Dashboard {

    private _weekDashboardIdTrigger: string = "triggerWeekDashboard";

    private _dayDashboardIdTrigger: string = "triggerDayDashboard";

    private _weekDashboardId: string = "weekDashboard";

    private _dayDashboardId: string = "dayDashboard";

    private _hideWeek: string = "Wochen Übersicht verstecken";

    private _showWeek: string = "Wochen Übersicht anzeigen";

    private _hideDay: string = "Tages Übersicht verstecken";

    private _showDay: string = "Tages Übersicht anzeigen";
    
    public init(): void {
        let weekDashboard: HTMLDivElement = <HTMLDivElement>document.getElementById(this._weekDashboardId);
        let dayDashboard: HTMLDivElement = <HTMLDivElement>document.getElementById(this._dayDashboardId);
        let weekDashboardTrigger: HTMLButtonElement = <HTMLButtonElement>document.getElementById(this._weekDashboardIdTrigger);
        let dayDashboardTrigger: HTMLButtonElement = <HTMLButtonElement>document.getElementById(this._dayDashboardIdTrigger);

        weekDashboard.style.display = "none";
        weekDashboardTrigger.innerHTML = this._showWeek;
        weekDashboardTrigger.onclick = () => { this.toggleWeekDashboard(); };
        dayDashboard.style.display = "block";
        dayDashboardTrigger.innerHTML = this._hideDay;
        dayDashboardTrigger.onclick = () => { this.toggleDayDashboard(); };

    }

    private toggleWeekDashboard(): void {
        let weekDashboard: HTMLDivElement = <HTMLDivElement>document.getElementById(this._weekDashboardId);
        let weekDashboardTrigger: HTMLButtonElement = <HTMLButtonElement>document.getElementById(this._weekDashboardIdTrigger);

        if (weekDashboard.style.display === "none") {
            weekDashboard.style.display = "block";
            weekDashboardTrigger.innerHTML = this._hideWeek;
        } else {
            weekDashboard.style.display = "none";
            weekDashboardTrigger.innerHTML = this._showWeek;
        }
    }

    private toggleDayDashboard(): void {
        let dayDashboard: HTMLDivElement = <HTMLDivElement>document.getElementById(this._dayDashboardId);
        let dayDashboardTrigger: HTMLButtonElement = <HTMLButtonElement>document.getElementById(this._dayDashboardIdTrigger);

        if (dayDashboard.style.display === "none") {
            dayDashboard.style.display = "block";
            dayDashboardTrigger.innerHTML = this._hideDay;
        } else {
            dayDashboard.style.display = "none";
            dayDashboardTrigger.innerHTML = this._showDay;
        }
    }
}