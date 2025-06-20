namespace API.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateOnly dob) // Método de extensión que calcula la edad a partir de una fecha de nacimiento (dob = date of birth)
        {
            var today = DateOnly.FromDateTime(DateTime.Now); // Obtiene la fecha actual (sin hora) y la guarda en 'today'

            var Age = today.Year - dob.Year; // Calcula una edad preliminar restando los años entre hoy y la fecha de nacimiento

            if (dob > today.AddYears(-Age)) Age--; // Si la persona aún no cumplió años este año, se resta 1 a la edad

            return Age; // Devuelve la edad calculada
        }
    }
}
