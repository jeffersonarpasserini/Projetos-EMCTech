-- Evento para atualização diaria dos juros e multa do contas a receber

CREATE 
	DEFINER = 'root'@'localhost'
EVENT secol.evt_corrige_juros_ctareceber
	ON SCHEDULE EVERY '1' DAY
	STARTS '2014-08-10 01:00:00'
	ON COMPLETION PRESERVE
	COMMENT 'Correcao de juros no contas a receber'
	DO 
BEGIN

  update receberparcela p 
  set p.jurosprevisto = juroscompostos( (select taxajuros from receberdocumento d where d.idreceberdocumento = p.idreceberdocumento ), p.saldopagar, p.datavencimento ), 
    p.dtaultcalcjuros = Now(), 
    p.multaprevista = round( (p.saldopagar*( (select taxamulta from receberdocumento d where d.idreceberdocumento = p.idreceberdocumento)/100 )), 2 ) 
  where p.situacao = 'A';

END;

ALTER EVENT secol.evt_corrige_juros_ctareceber
	ENABLE