using System;

namespace AlloyWheelsBuilderModel
{
    //TODO: XML +

    /// <summary>
    /// Класс <see cref="SetParameterValueArgs"/> 
    /// представляет информацию о параметре, 
    /// который не прошел валидацию
    /// </summary>
    public class SetParameterValueArgs: EventArgs
    {
        /// <summary>
        /// Возвращает и устанавливает имя параметра
        /// </summary>
        public AlloyWheelsParameterName ParameterName { get; set; }

        /// <summary>
        /// Возвращает и устанавливает сообщение об ошибке
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Инициализирует объект класса <see cref="SetParameterValueArgs"/>
        /// </summary>
        /// <param name="parameterName">Имя параметра</param>
        /// <param name="message">Сообщение об ошибке</param>
        public SetParameterValueArgs(AlloyWheelsParameterName parameterName,
            string message)
		{
            ParameterName = parameterName;
            Message = message;
		}
    }
}
