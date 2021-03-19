DROP VIEW dbo.ods_meta_vw;
DROP VIEW dbo.ods_vinculo_meta_municipio_vw;

DROP VIEW dbo.ods_tablero_indicador_vw;
DROP VIEW dbo.ods_tablero_indicador_ods_vw;

DROP TABLE dbo.ods_seguimiento_tarea;
DROP TABLE dbo.ods_tarea;
DROP TABLE dbo.ods_estado_tarea;
DROP TABLE dbo.ods_tactica;
DROP TABLE dbo.ods_vinculo_meta_municipio;
DROP TABLE dbo.ods_meta_municipio;
DROP TABLE dbo.ods_interesado;
DROP TABLE dbo.ods_tablero_indicador;
DROP TABLE dbo.ods_indicador;
DROP TABLE dbo.ods_objetivo_municipio;
DROP TABLE dbo.ods_municipio;
DROP TABLE dbo.ods_estado;
DROP TABLE dbo.ods_pais;
DROP TABLE dbo.ods_meta;
DROP TABLE dbo.ods_objetivo;
DROP TABLE dbo.ods_system;

CREATE TABLE dbo.ods_system
(
  Clave       VARCHAR(255) NOT NULL,
  Descripcion VARCHAR(MAX) NOT NULL,
  Valor       VARCHAR(MAX) NOT NULL
  CONSTRAINT pk_ods_system PRIMARY KEY(Clave)
);

CREATE TABLE dbo.ods_objetivo
(
  IdObjetivo INTEGER      NOT NULL IDENTITY(1,1),
  Objetivo   VARCHAR(MAX) NOT NULL,
  CONSTRAINT pk_ods_objetivo PRIMARY KEY(IdObjetivo)
);

CREATE TABLE dbo.ods_meta
(
  IdMeta     INTEGER      NOT NULL IDENTITY(1,1),
  Numeral    VARCHAR(10)  NOT NULL,
  Meta       VARCHAR(MAX) NOT NULL,
  IdObjetivo INTEGER      NOT NULL,
  CONSTRAINT pk_ods_meta PRIMARY KEY(IdMeta),
  CONSTRAINT fk_meta_objetivo FOREIGN KEY(IdObjetivo) REFERENCES ods_objetivo(IdObjetivo)
);

CREATE TABLE dbo.ods_pais
(
  IdPais INTEGER      NOT NULL IDENTITY(1,1),
  Pais   VARCHAR(256) NOT NULL,
  CONSTRAINT pk_ods_pais PRIMARY KEY(IdPais)
);

CREATE TABLE dbo.ods_estado
(
  IdEstado INTEGER       NOT NULL IDENTITY(1,1),
  Estado   VARCHAR(256)  NOT NULL,
  IdPais   INTEGER       NOT NULL,
  CONSTRAINT pk_ods_estado PRIMARY KEY(IdEstado),
  CONSTRAINT fk_estado_pais FOREIGN KEY(IdPais) REFERENCES ods_pais(IdPais)
);

CREATE TABLE dbo.ods_municipio
(
  IdMunicipio INTEGER       NOT NULL IDENTITY(1,1),
  Municipio   VARCHAR(256)  NOT NULL,
  IdEstado    INTEGER       NOT NULL,
  CONSTRAINT pk_ods_municipio PRIMARY KEY(IdMunicipio),
  CONSTRAINT fk_municipio_estado FOREIGN KEY(IdEstado) REFERENCES ods_estado(IdEstado)
);

CREATE TABLE dbo.ods_objetivo_municipio
 (
  IdObjetivoMunicipio INTEGER      NOT NULL IDENTITY(1,1),
  Numeral             VARCHAR(10)  NOT NULL, 
  ObjetivoMunicipio   VARCHAR(MAX) NOT NULL,
  Vigente             BIT          NOT NULL DEFAULT 1,
  IdMunicipio         INTEGER      NOT NULL,
  CONSTRAINT pk_ods_objetivo_municipio PRIMARY KEY(IdObjetivoMunicipio),
  CONSTRAINT fk_objetivo_municipio FOREIGN KEY(IdMunicipio) REFERENCES ods_municipio(IdMunicipio)
);

CREATE TABLE dbo.ods_tactica
(
  IdTactica   INTEGER      NOT NULL IDENTITY(1,1),
  Tactica     VARCHAR(MAX) NOT NULL,
  Vigente     BIT          NOT NULL DEFAULT 1,  
  IdMunicipio INTEGER      NOT NULL,
  CONSTRAINT pk_ods_tactica PRIMARY KEY(IdTactica),
  CONSTRAINT fk_tactica_municipio FOREIGN KEY(IdMunicipio) REFERENCES ods_municipio(IdMunicipio)
);

CREATE TABLE dbo.ods_indicador
(
  IdIndicador INTEGER      NOT NULL IDENTITY(1,1),
  Indicador   VARCHAR(MAX) NOT NULL,
  Vigente     BIT          NOT NULL DEFAULT 1,  
  IdMunicipio INTEGER      NOT NULL,
  CONSTRAINT pk_ods_indicador PRIMARY KEY(IdIndicador),
  CONSTRAINT fk_indicador_municipio FOREIGN KEY(IdMunicipio) REFERENCES ods_municipio(IdMunicipio)
);

CREATE TABLE dbo.ods_interesado
(
  IdInteresado       INTEGER       NOT NULL IDENTITY(1,1),
  Interesado         VARCHAR(255)  NOT NULL,
  Nombre             VARCHAR(255)  NOT NULL,
  Usuario            VARCHAR(50)   NOT NULL,
  Contrasenia        VARCHAR(1024) NOT NULL,
  CorreoRecuperacion VARCHAR(128)  NOT NULL,
  UltimaSesion       DATETIME      NOT NULL,
  IPUltimaSesion     VARCHAR(128)  NOT NULL,
  Administrador      BIT NOT NULL DEFAULT 0,
  SuperUsuario       BIT NOT NULL DEFAULT 0,
  Bloqueado          BIT NOT NULL DEFAULT 0,
  Activo             BIT NOT NULL DEFAULT 1,  
  IdMunicipio        INTEGER             NOT NULL,
  CONSTRAINT pk_ods_interesado PRIMARY KEY(IdInteresado),
  CONSTRAINT fk_interesados_municipio FOREIGN KEY(IdMunicipio) REFERENCES ods_municipio(IdMunicipio)
);

CREATE TABLE dbo.ods_meta_municipio
(
  IdMetaMunicipio     INTEGER      NOT NULL IDENTITY(1,1),
  MetaMuncipio        VARCHAR(MAX) NOT NULL,
  Anio                INTEGER      NOT NULL,  
  FechaInicio         DATE         NOT NULL,
  FechaTermino        DATE         NOT NULL,
  DebeCumplirse       DECIMAL      NOT NULL DEFAULT 0,
  EscalaPositiva      BIT          NOT NULL DEFAULT 1,
  Avance              DECIMAL      NOT NULL DEFAULT 0,
  Cumplida            BIT          NOT NULL DEFAULT 0,
  IdIndicador         INTEGER      NOT NULL, 
  IdObjetivoMunicipio INTEGER      NOT NULL, 
  CONSTRAINT pk_ods_meta_municipio PRIMARY KEY(IdMetaMunicipio),
  CONSTRAINT fk_indicador_meta FOREIGN KEY(IdIndicador) REFERENCES ods_indicador(IdIndicador),
  CONSTRAINT fk_objetivo_meta_municipio FOREIGN KEY(IdObjetivoMunicipio) REFERENCES ods_objetivo_municipio(IdObjetivoMunicipio)

);

CREATE TABLE dbo.ods_tablero_indicador
(
  IdTableroIndicador  INTEGER NOT NULL IDENTITY(1,1),
  Anio                INTEGER NOT NULL,
  ValorIndicador      DECIMAL NOT NULL DEFAULT 0,
  ValorAlcanzado      DECIMAL NOT NULL DEFAULT 0,
  EscalaPositiva      BIT     NOT NULL DEFAULT 1,
  ods_objetivos       INTEGER NOT NULL DEFAULT 0,
  ods_metas           INTEGER NOT NULL DEFAULT 0,
  municipio_objetivos INTEGER  NOT NULL DEFAULT 0,
  municipio_metas     INTEGER  NOT NULL DEFAULT 0,
  municipio_tacticas  INTEGER  NOT NULL DEFAULT 0,
  municipio_tareas    INTEGER  NOT NULL DEFAULT 0,
  IdIndicador         INTEGER  NOT NULL,
  CONSTRAINT pk_ods_tablero_indicador PRIMARY KEY(IdTableroIndicador),
  CONSTRAINT fk_tablero_indicador FOREIGN KEY(IdIndicador) REFERENCES ods_indicador(IdIndicador)
);

CREATE TABLE dbo.ods_vinculo_meta_municipio
(
  IdVinculo INTEGER  NOT NULL IDENTITY(1,1),
  IdMeta INTEGER     NOT NULL,
  IdMetaMunicipio    INTEGER  NOT NULL,
  CONSTRAINT pk_ods_vinculo_meta_municipio PRIMARY KEY(IdVinculo),
  CONSTRAINT fk_meta_meta_municipio FOREIGN KEY(IdMeta) REFERENCES ods_meta(IdMeta),
  CONSTRAINT fk_meta_municipio_meta FOREIGN KEY(IdMetaMunicipio) REFERENCES ods_meta_municipio(IdMetaMunicipio),
  CONSTRAINT uc_vinculo_meta_municipio UNIQUE(IdMeta, IdMetaMunicipio)
);

CREATE TABLE dbo.ods_estado_tarea
(
  IdEstadoTarea INTEGER NOT NULL IDENTITY(1,1),
  EstadoTarea   VARCHAR(256) NOT NULL,
  CONSTRAINT pk_ods_estado_tarea PRIMARY KEY(IdEstadoTarea)
);    

CREATE TABLE dbo.ods_tarea
(
  IdTarea          INTEGER      NOT NULL IDENTITY(1,1),
  Tarea            VARCHAR(MAX) NOT NULL,
  FechaInicio      DATE         NOT NULL,
  FechaTermino     DATE         NOT NULL,
  FechaInicioReal  DATE,
  FechaTerminoReal DATE,  
  Avance           DECIMAL      NOT NULL DEFAULT 0,
  IdEstadoTarea    INTEGER      NOT NULL,
  IdTactica        INTEGER      NOT NULL,  
  IdInteresado     INTEGER      NOT NULL,
  IdMetaMunicipio  INTEGER      NOT NULL,
  CONSTRAINT pk_ods_tarea PRIMARY KEY(IdTarea),
  CONSTRAINT fk_meta_tarea FOREIGN KEY(IdMetaMunicipio) REFERENCES ods_meta_municipio(IdMetaMunicipio),
  CONSTRAINT fk_interesado_tarea FOREIGN KEY(IdInteresado) REFERENCES ods_interesado(IdInteresado),
  CONSTRAINT fk_tactica_tarea FOREIGN KEY(IdTactica) REFERENCES ods_tactica(IdTactica),
  CONSTRAINT fk_estado_tarea FOREIGN KEY(IdEstadoTarea) REFERENCES ods_estado_tarea(IdEstadoTarea)
);

CREATE TABLE dbo.ods_seguimiento_tarea
(
  IdSeguimiento INTEGER      NOT NULL IDENTITY(1,1),
  Fecha         DATE         NOT NULL,
  Avance        DECIMAL      NOT NULL DEFAULT 0,
  Comentarios   VARCHAR(MAX) NOT NULL,
  IdInteresado  INTEGER      NOT NULL,
  IdTarea       INTEGER      NOT NULL,
  CONSTRAINT pk_ods_seguimiento_tarea PRIMARY KEY(IdSeguimiento),
  CONSTRAINT fk_seguimiento_tarea FOREIGN KEY(IdTarea) REFERENCES ods_tarea(IdTarea),
  CONSTRAINT fk_interesado_seguimiento_tarea FOREIGN KEY(IdInteresado) REFERENCES ods_interesado(IdInteresado)
);

--//Vistas:
--//--
CREATE VIEW dbo.ods_tablero_indicador_vw
AS
SELECT tab.IdTableroIndicador,tab.IdIndicador, tab.Anio, mun.Municipio, ind.Indicador, tab.ValorIndicador, tab.ValorAlcanzado,
       tab.EscalaPositiva, tab.ods_objetivos, tab.ods_metas, tab.municipio_objetivos, tab.municipio_metas,
	   tab.municipio_tacticas, tab.municipio_tareas, mun.IdMunicipio,  ind.Vigente
  FROM ods_tablero_indicador tab
 INNER JOIN ods_indicador ind
    ON tab.IdIndicador = ind.IdIndicador
 INNER JOIN ods_municipio mun
    ON ind.IdMunicipio = mun.IdMunicipio;
    
CREATE VIEW dbo.ods_tablero_indicador_ods_vw
AS
SELECT IdMunicipio, Municipio, Anio, IdObjetivo, Objetivo,  
       COUNT(IdMetaMunicipio) AS MetasODS,
	   COUNT(IdObjetivoMunicipio) AS ObjetivosMunicipio,
	   COUNT(IdMetaMunicipio) AS MetasMunicipio, 
	   COUNT(Indicador) AS IndicadoresMunicipio,   
      (SUM(t.AVANCE) * 100) / SUM(t.DebeCumplirse) AS Avance
FROM (
SELECT obj.IdObjetivo, obj.Objetivo, met.Numeral, met.Meta, mno.MetaMuncipio, mno.Anio, 
       mno.DebeCumplirse, mno.AVANCE, mno.EscalaPositiva, mno.FechaInicio, mno.FechaTermino,
	   obm.Numeral AS NumeralObjetivo, obm.ObjetivoMunicipio, obm.Vigente AS ObjetivoVigente,
	   ind.Indicador, ind.Vigente AS IndicadorVigente, mun.Municipio,
       met.IdMeta, mno.IdMetaMunicipio, mno.IdObjetivoMunicipio, mno.IdIndicador, obm.IdMunicipio
  FROM ods_objetivo obj
 INNER JOIN ods_meta met
    ON obj.IdObjetivo = met.IdObjetivo
 INNER JOIN ods_vinculo_meta_municipio vin
    ON met.IdMeta = vin.IdMeta
 INNER JOIN ods_meta_municipio mno
    ON vin.IdMetaMunicipio = mno.IdMetaMunicipio
 INNER JOIN ods_objetivo_municipio obm
    ON mno.IdObjetivoMunicipio = obm.IdObjetivoMunicipio
 INNER JOIN ods_indicador ind
    ON mno.IdIndicador = ind.IdIndicador
 INNER JOIN ods_municipio mun
    ON obm.IdMunicipio = mun.IdMunicipio
) t
GROUP BY IdMunicipio, Municipio, Anio, IdObjetivo, Objetivo;    
    
CREATE VIEW dbo.ods_meta_vw
AS
SELECT obj.IdObjetivo, obj.Objetivo, met.Numeral, met.Meta, 
       met.IdMeta 
  FROM ods_objetivo obj
 INNER JOIN ods_meta met
    ON obj.IdObjetivo = met.IdObjetivo;    


CREATE VIEW dbo.ods_vinculo_meta_municipio_vw
AS
SELECT obj.IdObjetivo, obj.Objetivo, met.Numeral, met.Meta, mno.MetaMuncipio, mno.Anio, 
       mno.DebeCumplirse, mno.AVANCE, mno.EscalaPositiva, mno.FechaInicio, mno.FechaTermino,
	   obm.Numeral AS NumeralObjetivo, obm.ObjetivoMunicipio, obm.Vigente AS ObjetivoVigente,
	   ind.Indicador, ind.Vigente AS IndicadorVigente, mun.Municipio,
       met.IdMeta, mno.IdMetaMunicipio, mno.IdObjetivoMunicipio, mno.IdIndicador, obm.IdMunicipio
  FROM ods_objetivo obj
 INNER JOIN ods_meta met
    ON obj.IdObjetivo = met.IdObjetivo
 INNER JOIN ods_vinculo_meta_municipio vin
    ON met.IdMeta = vin.IdMeta
 INNER JOIN ods_meta_municipio mno
    ON vin.IdMetaMunicipio = mno.IdMetaMunicipio
 INNER JOIN ods_objetivo_municipio obm
    ON mno.IdObjetivoMunicipio = obm.IdObjetivoMunicipio
 INNER JOIN ods_indicador ind
    ON mno.IdIndicador = ind.IdIndicador
 INNER JOIN ods_municipio mun
    ON obm.IdMunicipio = mun.IdMunicipio;




--//Triggers:
--//----------------------------------------------------------------------------

--//Actualiza la tarea asociada al seguimiento con
--//el valor indicado en el último seguimiento.
CREATE TRIGGER dbo.ods_actualiza_avance_tarea_trg
ON ods_seguimiento_tarea
AFTER   
INSERT, UPDATE, DELETE   
AS 
BEGIN
   
   DECLARE @IdTarea         INT;
   DECLARE @FechaInicioReal DATE;
   DECLARE @Avance          DECIMAL;
   
   SET NOCOUNT ON;

   SELECT @IdTarea = IdTarea 
     FROM (SELECT IdTarea
             FROM ods_seguimiento_tarea
            WHERE IdSeguimiento IN(SELECT MAX(IdSeguimiento) IdSeguimiento
	                                 FROM ods_seguimiento_tarea
			                        WHERE IdTarea IN(SELECT IdTarea FROM inserted UNION SELECT IdTarea FROM deleted)
                                  )  
           ) t;
         
   UPDATE ods_tarea
      SET ods_tarea.Avance = q.Avance,
          ods_tarea.IdEstadoTarea = 2
	 FROM (SELECT IdTarea, Avance
             FROM ods_seguimiento_tarea
            WHERE IdSeguimiento IN(SELECT MAX(IdSeguimiento) IdSeguimiento
	                                 FROM ods_seguimiento_tarea
			                        WHERE IdTarea IN(SELECT IdTarea FROM inserted UNION SELECT IdTarea FROM deleted)
                                  )            
	      )q
    WHERE ods_tarea.IdTarea = q.IdTarea;   
    
   IF @@ROWCOUNT > 0
   BEGIN
   
     SELECT @FechaInicioReal = FechaInicioReal, @Avance = Avance
       FROM ods_tarea
      WHERE IdTarea = @IdTarea;  
     
     IF @FechaInicioReal IS NULL
     BEGIN
        UPDATE ods_tarea
           SET FechaInicioReal = GETDATE()
         WHERE IdTarea = @IdTarea;
     END;
     
     IF @Avance >= 100
     BEGIN
        UPDATE ods_tarea
           SET FechaTerminoReal = GETDATE()
         WHERE IdTarea = @IdTarea;     
     END;
   
   END;    
    
END;



--//Actualiza la meta asociada a la tarea
--//realizando el prorrateo de porcentaje de acuerdo
--//al número de tareas asociadas.
CREATE TRIGGER dbo.ods_actualiza_avance_meta_trg
ON ods_tarea
AFTER   
INSERT, UPDATE, DELETE   
AS 
BEGIN
   
   SET NOCOUNT ON;

   DECLARE @DebeCumplirse   DECIMAL;
   DECLARE @IdMetaMunicipio INT;
   DECLARE @TotalTareas      INT;

   --//1.-Obtener el valor de la meta a cumplirse.
   SELECT @DebeCumplirse = ISNULL(DebeCumplirse,0)
     FROM ods_meta_municipio
	WHERE IdMetaMunicipio IN(SELECT IdMetaMunicipio FROM inserted UNION SELECT IdMetaMunicipio FROM deleted);

   IF @DebeCumplirse IS NULL
   BEGIN
     SET @DebeCumplirse = 0;
   END;

   --//2.- Obtener el número de tareas asociadas a la meta.
   SELECT @IdMetaMunicipio = IdMetaMunicipio, @TotalTareas = COUNT(IdMetaMunicipio) 
     FROM ods_tarea
    WHERE IdMetaMunicipio IN(SELECT IdMetaMunicipio FROM inserted UNION SELECT IdMetaMunicipio FROM deleted)
      AND IdEstadoTarea <> 5
    GROUP BY IdMetaMunicipio;

   IF @TotalTareas IS NULL
   BEGIN
      SET @TotalTareas = 0;
   END;

   IF @TotalTareas = 0
   BEGIN
      SET @TotalTareas = 1;
   END;

   --//3.- Actualizar el avance de la meta de acuerdo al avance de las tareas.
   UPDATE ods_meta_municipio
      SET ods_meta_municipio.Avance = ((q.Avance / @TotalTareas) * @DebeCumplirse) / 100
	 FROM (SELECT IdMetaMunicipio, SUM(ISNULL(Avance,0)) AS Avance
	         FROM ods_tarea
			WHERE IdMetaMunicipio IN(SELECT IdMetaMunicipio FROM inserted UNION SELECT IdMetaMunicipio FROM deleted)
            GROUP BY IdMetaMunicipio
	      )q
    WHERE ods_meta_municipio.IdMetaMunicipio = q.IdMetaMunicipio;
   
END;

--//Actualiza el avance del indicador realizando el
--//prorrateo de porcentaje de acuerdo al número de metas
--//asociadas al indicador del mismo año.
CREATE TRIGGER dbo.ods_actualiza_avance_indicador_trg
ON ods_meta_municipio
AFTER   
INSERT, UPDATE, DELETE   
AS 
BEGIN
   
   SET NOCOUNT ON;

   DECLARE @IdIndicador             INT;
   DECLARE @ValorIndicador          DECIMAL;   
   DECLARE @Anio                    INT;
   DECLARE @TotalObjetivos          INT;
   DECLARE @TotalMetas              INT;    
   DECLARE @TotalMetasMunicipio     INT;
   DECLARE @TotalObjetivosMunicipio INT;
   DECLARE @TotalTareasMunicipio    INT;
   DECLARE @TotalTacticasMunicipio  INT; 
   

   --//1.-Obtener el indicador y el año de la meta agregada, insertada o eliminada.
   SELECT @IdIndicador = IdIndicador, @Anio = Anio
     FROM (SELECT IdIndicador, Anio 
             FROM inserted 
            UNION 
           SELECT IdIndicador, Anio 
             FROM deleted
          )t;
      
--    --//2.-Obtener el valor del indicador a cumplir.
--    SELECT @ValorIndicador = ISNULL(ValorIndicador,0), @Anio = Anio
--      FROM ods_tablero_indicador
-- 	WHERE IdIndicador = @IdIndicador
-- 	  AND Anio = @Anio;
-- 
-- --    IF @@ROWCOUNT = 0
-- --    BEGIN
-- --      EXIT 0;
-- --    END
--    
--    IF @ValorIndicador IS NULL
--    BEGIN
--      SET @ValorIndicador = 0;
--    END;

   --//3.- Obtener el número de metas del municipio asociadas al indicador.
   SELECT @TotalMetasMunicipio = COUNT(IdMetaMunicipio) 
     FROM ods_meta_municipio
    WHERE IdIndicador = @IdIndicador
	  AND Anio = @Anio;

   IF @TotalMetasMunicipio IS NULL
   BEGIN
     SET @TotalMetasMunicipio = 0;
   END;

   IF @TotalMetasMunicipio = 0
   BEGIN
     SET @TotalMetasMunicipio = 1;
   END;
   
   --//4.- Obtener el número de objetivos del municipio asociadas a las metas 
   --//    que estan asociadas al indicador.
   SELECT @TotalObjetivosMunicipio = COUNT(DISTINCT IdObjetivoMunicipio) 
     FROM ods_meta_municipio
    WHERE IdIndicador = @IdIndicador
	  AND Anio = @Anio;
    
   IF @TotalObjetivosMunicipio IS NULL
   BEGIN
     SET @TotalObjetivosMunicipio = 0;
   END;  
   
   --//5.- Obtener el número de metas ods asociadas a las metas 
   --//    que estan asociadas al indicador.   
   SELECT @TotalMetas = COUNT(IdMeta) 
     FROM ods_meta
    WHERE IdMeta IN(SELECT IdMeta 
                      FROM ods_vinculo_meta_municipio 
				     WHERE IdMetaMunicipio IN(SELECT IdMeta 
				                                FROM ods_meta_municipio
											   WHERE IdIndicador = @IdIndicador
											     AND Anio = @Anio
										     )
	              ); 
                  
   IF @TotalMetas IS NULL
   BEGIN
     SET @TotalMetas = 0;
   END;                      
   
   --//6.- Obtener el número de objetivos ods asociadas a las metas 
   --//    que estan asociadas al indicador.    
   SELECT @TotalObjetivos = COUNT(DISTINCT IdObjetivo) 
     FROM ods_meta
    WHERE IdMeta IN(SELECT IdMeta 
                      FROM ods_vinculo_meta_municipio 
				     WHERE IdMetaMunicipio IN(SELECT IdMeta 
				                                FROM ods_meta_municipio
											   WHERE IdIndicador = @IdIndicador
											     AND Anio = @Anio
										     )
	              ); 
                  
   IF @TotalObjetivos IS NULL
   BEGIN
     SET @TotalObjetivos = 0;
   END;  
     
   --//7.- Obtener el número de tareas asociadas a las metas 
   --//    que estan asociadas al indicador.        
   SELECT @TotalTareasMunicipio = COUNT(IdTarea) 
     FROM ods_tarea
    WHERE IdMetaMunicipio IN(SELECT IdMetaMunicipio 
                               FROM ods_meta_municipio
                              WHERE IdIndicador = @IdIndicador
	                            AND Anio = @Anio
                             );    
                             
   IF @TotalTareasMunicipio IS NULL
   BEGIN
     SET @TotalTareasMunicipio = 0;
   END; 
   
   --//8.- Obtener el número de tacticas asociadas a las tareas asociadas a las  
   --//    metas que estan asociadas al indicador.        
   SELECT @TotalTacticasMunicipio = COUNT(DISTINCT IdTactica) 
     FROM ods_tarea
    WHERE IdMetaMunicipio IN(SELECT IdMetaMunicipio 
                               FROM ods_meta_municipio
                              WHERE IdIndicador = @IdIndicador
	                            AND Anio = @Anio
                             );    
                             
   IF @TotalTacticasMunicipio IS NULL
   BEGIN
     SET @TotalTacticasMunicipio = 0;
   END;                                  
       
   --//9.- Actualizar el avance del indicador de acuerdo al avance de las metas.
   UPDATE ods_tablero_indicador
      SET ods_tablero_indicador.ValorAlcanzado = ((q.Avance / @TotalMetasMunicipio) * ods_tablero_indicador.ValorIndicador) / 100,
          ods_tablero_indicador.ods_objetivos = @TotalObjetivos,
          ods_tablero_indicador.ods_metas = @TotalMetas,
	      ods_tablero_indicador.municipio_metas = @TotalMetasMunicipio,
          ods_tablero_indicador.municipio_objetivos = @TotalObjetivosMunicipio,
          ods_tablero_indicador.municipio_tacticas = @TotalTacticasMunicipio,
          ods_tablero_indicador.municipio_tareas = @TotalTareasMunicipio        
	 FROM (SELECT Anio, IdIndicador, SUM(ISNULL(Avance,0)) AS Avance
	         FROM ods_meta_municipio
			WHERE IdIndicador IN(SELECT IdIndicador FROM inserted UNION SELECT IdIndicador FROM deleted)
			  AND Anio = @Anio
            GROUP BY Anio, IdIndicador
	      )q
    WHERE ods_tablero_indicador.Anio = q.Anio
	  AND ods_tablero_indicador.IdIndicador = q.IdIndicador;
      

   
END;

