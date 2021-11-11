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

        weekDashboard.style.display = "block";
        weekDashboardTrigger.innerHTML = this._hideWeek;
        weekDashboardTrigger.onclick = () => { this.toggleWeekDashboard(); };
        dayDashboard.style.display = "none";
        dayDashboardTrigger.innerHTML = this._showDay;
        dayDashboardTrigger.onclick = () => { this.toggleDayDashboard(); };

    }

    private toggleWeekDashboard(): void {
        let weekDashboard: HTMLDivElement = <HTMLDivElement>document.getElementById(this._weekDashboardId);
        let dayDashboard: HTMLDivElement = <HTMLDivElement>document.getElementById(this._dayDashboardId);
        let weekDashboardTrigger: HTMLButtonElement = <HTMLButtonElement>document.getElementById(this._weekDashboardIdTrigger);
        let dayDashboardTrigger: HTMLButtonElement = <HTMLButtonElement>document.getElementById(this._dayDashboardIdTrigger);

        if (weekDashboard.style.display === "none") {
            weekDashboard.style.display = "block";
            dayDashboard.style.display = "none";
            weekDashboardTrigger.innerHTML = this._hideWeek;
            dayDashboardTrigger.innerHTML = this._showDay;
        } else {
            weekDashboard.style.display = "none";
            weekDashboardTrigger.innerHTML = this._showWeek;
        }
    }

    private toggleDayDashboard(): void {
        let weekDashboard: HTMLDivElement = <HTMLDivElement>document.getElementById(this._weekDashboardId);
        let dayDashboard: HTMLDivElement = <HTMLDivElement>document.getElementById(this._dayDashboardId);
        let weekDashboardTrigger: HTMLButtonElement = <HTMLButtonElement>document.getElementById(this._weekDashboardIdTrigger);
        let dayDashboardTrigger: HTMLButtonElement = <HTMLButtonElement>document.getElementById(this._dayDashboardIdTrigger);

        if (dayDashboard.style.display === "none") {
            dayDashboard.style.display = "block";
            weekDashboard.style.display = "none";
            dayDashboardTrigger.innerHTML = this._hideDay;
            weekDashboardTrigger.innerHTML = this._showWeek;
        } else {
            dayDashboard.style.display = "none";
            dayDashboardTrigger.innerHTML = this._showDay;
        }
    }
}