/*
-- Date: 2013-01-26 13:18
SCRIPT DE INICIALIZAÇÃO DO BANCO DE DADOS
*/

/*SISTEMA CADASTRO*/
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',1,'Cadastros','EMCCadastro',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',2,'Tabelas','EMCCadastro',NULL,NULL,'N','N','N',1,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',3,'Relatorios','EMCCadastro',NULL,NULL,'N','N','N',2,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',101,'Holding','EMCCadastro','frmHolding',NULL,'N','N','S',1,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',102,'Grupo Empresas','EMCCadastro','frmGrupoEmpresa',NULL,'N','N','S',2,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',110,'Empresa','EMCCadastro','frmEmpresa',NULL,'N','N','S',3,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',115,'Pessoa','EMCCadastro','frmPessoa',NULL,'N','N','S',4,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',997,'Telefone','EMCCadastro','frmContato',NULL,'N','N','S',1,3,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',998,'Cliente','EMCCadastro','frmCliente',NULL,'N','N','S',2,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',999,'Fornecedor','EMCCadastro','frmFornecedor',NULL,'N','N','S',2,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',120,'Conta Bancaria','EMCCadastro','frmCtaBancaria',NULL,'N','N','S',3,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',125,'Centro de Custos','EMCCadastro','frmContaCusto',NULL,'N','N','S',4,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',130,'Aplicação','EMCCadastro','frmAplicacao',NULL,'N','N','S',5,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',210,'Cep','EMCCadastro','frmCep',NULL,'N','N','S',1,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',215,'Banco','EMCCadastro','frmBanco',NULL,'N','N','S',2,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',220,'Feriados','EMCCadastro','frmFeriado',NULL,'N','N','S',3,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',225,'Indexadores','EMCCadastro','frmIndexador',NULL,'N','N','S',4,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',230,'Indices Financeiros','EMCCadastro','frmIndice',NULL,'N','N','S',5,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',235,'Tipo Documento','EMCCadastro','frmTipoDocumento',NULL,'N','S','S',6,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',240,'Forma Pagamento','EMCCadastro','frmFormaPagamento',NULL,'N','S','S',7,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',245,'Tipo Cobrança','EMCCadastro','frmTipoCobranca',NULL,'N','N','S',8,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',250,'Histórico','EMCCadastro','frmHistorico',NULL,'N','N','S',9,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',255,'Componente de Custo - Grupo','EMCCadastro','frmCusto_ComponenteGrupo',NULL,'N','N','S',10,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',260,'Componente de Custo','EMCCadastro','frmCusto_Componente',NULL,'N','N','S',11,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',265,'Estado','EMCCadastro','frmEstado',NULL,'N','N','S',12,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',270,'IBGE Cidade','EMCCadastro','frmIbgeCidade',NULL,'N','N','S',13,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',275,'Cidade','EMCCadastro','frmCidade',NULL,'N','N','S',14,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',310,'Realtorio01','EMCCadastro',NULL,NULL,'N','N','N',1,3,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',320,'Relatorio02','EMCCadastro',NULL,NULL,'N','N','N',2,3,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',31005,'EmRelatorio01','EMCCadastro',NULL,NULL,'N','N','S',1,310,2,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',31010,'EmRelatorio02','EMCCadastro',NULL,NULL,'N','N','S',2,310,2,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCCadastro',32005,'EmRelatorio03','EMCCadastro',NULL,NULL,'N','N','S',1,320,2,'N');


/*SISTEMA SEGURANCA*/
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCSecurity',1,'Cadastro','EMCSecurity',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCSecurity',101,'Usuário','EMCSecurity','frmUsuario',NULL,'N','N','S',1,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCSecurity',105,'Aplicação','EMCSecurity','frmAplicacao',NULL,'N','N','S',2,1,1,'S');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCSecurity',108,'Usuario x Aplicação','EMCSecurity','frmUsuarioAplicacao',NULL,'N','N','S',2,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCSecurity',110,'Menu Sistema','EMCSecurity','frmMenuSistema',NULL,'N','N','S',3,1,1,'S');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCSecurity',115,'Menu Usuário','EMCSecurity','frmMenuUsuario',NULL,'N','N','S',4,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCSecurity',120,'Usuário x Empresa','EMCSecurity','frmUsuarioEmpresa',NULL,'N','N','S',5,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCSecurity',130,'Parematros Sistema','EMCSecurity','frmParametros',NULL,'N','N','S',5,1,1,'N');

/*SISTEMA IMOB*/
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCImob',1,'Cadastros','EMCImob',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCImob',110,'Comodo','EMCImob','frmComodo',NULL,'N','N','S',1,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCImob',115,'Tipo Imóvel','EMCImob','frmTipoImovel',NULL,'N','N','S',2,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCImob',120,'Carteira Imovel','EMCImob','frmCarteiraImoveis',NULL,'N','N','S',3,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCImob',125,'Tipo Lançamento Captação','EMCImob','frmTipoLanctoCaptacao',NULL,'N','N','S',4,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCImob',130,'Proventos','EMCImob','frmLocacaoProventos',NULL,'N','N','S',5,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCImob',135,'Imóvel','EMCImob','frmImovel',NULL,'N','N','S',6,1,1,'N');

INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCImob',2,'Movimento','EMCImob',NULL,NULL,'N','N','N',1,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCImob',200,'Captação Vendedor','EMCImob','frmContasCaptacao',NULL,'N','N','S',1,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCImob',205,'Despesa Imovel','EMCImob','frmDespesaImovel',NULL,'N','N','S',2,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCImob',210,'Captação Vendedor','EMCImob','frmIPTU',NULL,'N','N','S',3,2,1,'N');

INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCImob',3,'Locação Imoveis','EMCImob',NULL,NULL,'N','N','N',3,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCImob',300,'Contrato Locação Imovel','EMCImob','frmContratoLocacao',NULL,'N','N','S',1,3,1,'N');

INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCImob',4,'Relatorios','EMCImob',NULL,NULL,'N','N','N',4,0,0,'N');


/*SISTEMA FINANCEIRO*/
/* Menu Geral Financeiro */
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 1,'Contas a Pagar','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 2,'Contas a Receber','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 3,'Controle Bancário','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 4,'Controle de Caixa','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 5,'Cheques/Recibos','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 6,'Relatórios','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 7,'Processamento','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N');


/* Contas a Pagar */
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 105,'Documento a Pagar','EMCFinanceiro','frmPagarDocumento',NULL,'N','N','S',1,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 998,'Pagar Base Rateio','EMCFinanceiro','frmPagarBaseRateio',NULL,'N','N','S',1,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 110,'Liberação Pagamento','EMCFinanceiro','frmPagarLiberacao',NULL,'N','N','S',2,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 115,'Baixa Documentos','EMCFinanceiro','frmPagarBaixa',NULL,'N','N','S',3,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 120,'Fatura Pagar','EMCFinanceiro','frmPagarFatura',NULL,'N','N','S',4,1,1,'N');

/* Contas a Receber */
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 205,'Formulários Boletos','EMCFinanceiro','frmReceberFormulario',NULL,'N','N','S',1,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 210,'Documento a Receber','EMCFinanceiro','frmReceberDocumento',NULL,'N','N','S',2,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 213,'Acordo Financeiro','EMCFinanceiro','frmReceberAcordo',NULL,'N','N','S',3,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 997,'Receber Base Rateio','EMCFinanceiro','frmReceberBaseRateio',NULL,'N','N','S',1,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 215,'Baixa Documentos','EMCFinanceiro','frmReceberBaixa',NULL,'N','N','S',4,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 220,'Fatura Receber','EMCFinanceiro','frmReceberFatura',NULL,'N','N','S',5,2,1,'N');
/* Banco */
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 999,'Movimentação Bancaria','EMCFinanceiro','frmMovimentoBancario',NULL,'N','N','S',1,3,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 305,'Movimentação Bancaria','EMCFinanceiro','frmGrdMovBancario',NULL,'N','N','S',1,3,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 310,'Tarifas Bancarias','EMCFinanceiro','frmTarifasBancarias',NULL,'N','N','S',2,3,1,'N');

/* Caixa */
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 400,'Abertura de Caixa','EMCFinanceiro','frmAbreCaixa',NULL,'N','N','S',1,4,1,"N");
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 410,'Fechamento de Caixa','EMCFinanceiro','frmFechaCaixa',NULL,'N','N','S',2,4,1,"N");
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 420,'Conferência de Caixa','EMCFinanceiro','frmConfereCaixa',NULL,'N','N','S',3,4,1,"N");

/*Cheques e Recibos */
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 500,'Emissão de Cheques','EMCFinanceiro','frmEmissaoCheques',NULL,'N','N','S',1,5,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 505,'Emissão de Recibos','EMCFinanceiro','frmEmissaoRecibos',NULL,'N','N','S',2,5,1,'N');

/* Relatorios */
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 600,'Contas a Pagar','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 60005,'Contas Pagas','EMCFinanceiro','relCtasPagarBaixa',NULL,'N','N','S',1,600,2,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 60010,'Contas a Pagar','EMCFinanceiro','relCtasPagar',NULL,'N','N','S',2,600,2,'N');

INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 610,'Contas a Receber','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 61005,'Contas Recebidas','EMCFinanceiro','relCtasRecebidas',NULL,'N','N','S',1,610,2,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 61010,'Contas a Receber','EMCFinanceiro','relCtasReceber',NULL,'N','N','S',2,610,2,'N');

INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 620,'Controle Bancario','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 62005,'Cheques Emitidos','EMCFinanceiro','relCtasRecebidas',NULL,'N','N','S',1,610,2,'N');

/* Processaemnto */
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFinanceiro', 700,'Integração Documentos','EMCFinanceiro','frmIntegracao',NULL,'N','N','S',1,7,1,'N');

/*SISTEMA FATURAMENTO*/
/* Menu Geral*/
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFaturamento', 1,'Notas Fiscais','EMCFaturamento',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFaturamento', 2,'Tabelas','EMCFaturamento',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFaturamento', 3,'Relatórios','EMCFaturamento',NULL,NULL,'N','N','N',0,0,0,'N');
/* Menu Notas Fiscais */

/* Menu Tabelas */
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFaturamento', 205,'Código Fiscal - CFOP','EMCFaturamento','frmFatu_CFOP',NULL,'N','N','S',1,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFaturamento', 210,'Nomenclatura Comum do Mercosul - NCM','EMCFaturamento','frmFatu_NCM',NULL,'N','N','S',2,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFaturamento', 215,'Origem Mercadoria','EMCFaturamento','frmFatu_OrigemMercadoria',NULL,'N','N','S',3,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFaturamento', 220,'Situação Fiscal IPI','EMCFaturamento','frmFatu_SituacaoFiscalIPI',NULL,'N','N','S',4,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFaturamento', 221,'Situação Fiscal Cofins','EMCFaturamento','frmFatu_SituacaoCofins',NULL,'N','N','S',4,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFaturamento', 222,'Situação Fiscal PIS','EMCFaturamento','frmFatu_SituacaoPis',NULL,'N','N','S',4,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFaturamento', 223,'Motivo ICMS','EMCFaturamento','frmFatu_MotivoIcms',NULL,'N','N','S',4,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFaturamento', 225,'Regime Tributação','EMCFaturamento','frmFatu_Tributacao',NULL,'N','N','S',5,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFaturamento', 227,'Regime Tributação IPI','EMCFaturamento','frmFatu_TributacaoIPI',NULL,'N','N','S',6,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCFaturamento', 230,'Natureza de Operação','EMCFaturamento','frmFatu_NaturezaOperacao',NULL,'N','N','S',7,2,1,'N');


/* SISTEM DE OBRAS */
/* Menu Geral*/
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCObras', 1,'Tabelas','EMCObras',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCObras', 2,'Movimentos','EMCObras',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCObras', 3,'Relatórios','EMCObras',NULL,NULL,'N','N','N',0,0,0,'N');
/* Menu Tabelas */
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCObras', 105,'Etapa','EMCObras','frmObra_Etapa',NULL,'N','N','S',1,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCObras', 110,'Módulo','EMCObras','frmObra_Modulo',NULL,'N','N','S',2,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCObras', 115,'Tarefa','EMCObras','frmObra_Tarefa',NULL,'N','N','S',3,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCObras', 120,'Tipo Contrato - OBras','EMCObras','frmObra_TipoContrato',NULL,'N','N','S',4,1,1,'N');
/* Menu Movimentação */
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCObras', 205,'Obra','EMCObras','frmObra',NULL,'N','N','S',1,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCObras', 210,'Cronograma de Obra','EMCObras','frmCronograma',NULL,'N','N','S',2,2,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCObras', 215,'Previsão Despesa','EMCObras','frmPrevisaoDespesa',NULL,'N','N','S',3,2,1,'N');

/* Controle de Estoque */
/* Menu Geral*/
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCEstoque', 1,'Cadastros','EMCEstoque',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCEstoque', 2,'Movimentos','EMCEstoque',NULL,NULL,'N','N','N',0,0,0,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCEstoque', 3,'Relatórios','EMCEstoque',NULL,NULL,'N','N','N',0,0,0,'N');
/* Menu Cadastros */
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCEstoque', 105,'Almoxarifado','EMCEstoque','frmEstq_Almoxarifado',NULL,'N','N','S',1,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCEstoque', 110,'Familia Produto','EMCEstoque','frmEstq_Familia',NULL,'N','N','S',2,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCEstoque', 115,'Grupo Produto','EMCEstoque','frmEstq_Grupo',NULL,'N','N','S',3,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCEstoque', 116,'SubGrupo Produto','EMCEstoque','frmEstq_SubGrupo',NULL,'N','N','S',4,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCEstoque', 120,'Tipo Produto','EMCEstoque','frmEstq_TipoProduto',NULL,'N','N','S',5,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCEstoque', 125,'Unidade','EMCEstoque','frmEstq_Produto_Unidade',NULL,'N','N','S',6,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCEstoque', 126,'Embalagem','EMCEstoque','frmEstq_Embalagem',NULL,'N','N','S',7,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCEstoque', 130,'Produto','EMCEstoque','frmEstq_Produto',NULL,'N','N','S',10,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCEstoque', 999,'Produto [Descrição]','EMCEstoque','frmEstq_Descricao',NULL,'N','N','S',1,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCEstoque', 998,'Produto [Fornecedor]','EMCEstoque','frmEstq_Produto_Fornecedor',NULL,'N','N','S',1,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCEstoque', 997,'Produto [Lote]','EMCEstoque','frmEstq_Produto_Lote',NULL,'N','N','S',1,1,1,'N');
INSERT INTO `menusistema` (`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`) VALUES ('EMCEstoque', 996,'Produto [Volume]','EMCEstoque','frmEstq_Produto_Volume',NULL,'N','N','S',1,1,1,'N');


//LIBERACAO DAS OPCOES PARA O USUARIO*****************************************************************************
/*MENU CADASTRO*/
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',1,'Cadastros','EMCCadastro',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',2,'Tabelas','EMCCadastro',NULL,NULL,'N','N','N',1,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',3,'Relatorios','EMCCadastro',NULL,NULL,'N','N','N',2,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',101,'Holding','EMCCadastro','frmHolding',NULL,'N','N','S',1,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',102,'Grupo Empresas','EMCCadastro','frmGrupoEmpresa',NULL,'N','N','S',2,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',110,'Empresa','EMCCadastro','frmEmpresa',NULL,'N','N','S',3,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',115,'Pessoa','EMCCadastro','frmPessoa',NULL,'N','N','S',4,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',997,'Contato','EMCCadastro','frmContato',NULL,'N','N','S',2,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',998,'Cliente','EMCCadastro','frmCliente',NULL,'N','N','S',2,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',999,'Fornecedor','EMCCadastro','frmFornecedor',NULL,'N','N','S',2,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',120,'Conta Bancaria','EMCCadastro','frmCtaBancaria',NULL,'N','N','S',3,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',125,'Centro de Custos','EMCCadastro','frmContaCusto',NULL,'N','N','S',4,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',130,'Aplicação','EMCCadastro','frmAplicacao',NULL,'N','N','S',5,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',210,'Cep','EMCCadastro','frmCep',NULL,'N','N','S',1,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',215,'Banco','EMCCadastro','frmBanco',NULL,'N','N','S',2,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',220,'Feriados','EMCCadastro','frmFeriado',NULL,'N','N','S',3,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',225,'Indexadores','EMCCadastro','frmIndexador',NULL,'N','N','S',4,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',230,'Indices Financeiros','EMCCadastro','frmIndice',NULL,'N','N','S',5,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',235,'Tipo Documento','EMCCadastro','frmTipoDocumento',NULL,'N','S','S',6,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',240,'Forma Pagamento','EMCCadastro','frmFormaPagamento',NULL,'N','S','S',7,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',245,'Tipo Cobrança','EMCCadastro','frmTipoCobranca',NULL,'N','N','S',8,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',250,'Histórico','EMCCadastro','frmHistorico',NULL,'N','N','S',9,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`,`modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',255,'Componente de Custo - Grupo','EMCCadastro','frmCusto_ComponenteGrupo',NULL,'N','N','S',10,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`,`modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',260,'Componente de Custo','EMCCadastro','frmCusto_Componente',NULL,'N','N','S',11,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`,`modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',265,'Estado','EMCCadastro','frmEstado',NULL,'N','N','S',12,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`,`modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',270,'IBGE Cidade','EMCCadastro','frmIbgeCidade',NULL,'N','N','S',13,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`,`modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',275,'Cidade','EMCCadastro','frmCidade',NULL,'N','N','S',14,2,1,'N','8','S','S','S','S','S','S');

INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',310,'Realtorio01','EMCCadastro',NULL,NULL,'N','N','N',1,3,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',320,'Relatorio02','EMCCadastro',NULL,NULL,'N','N','N',2,3,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',31005,'EmRelatorio01','EMCCadastro',NULL,NULL,'N','N','S',1,310,2,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',31010,'EmRelatorio02','EMCCadastro',NULL,NULL,'N','N','S',2,310,2,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCCadastro',32005,'EmRelatorio03','EMCCadastro',NULL,NULL,'N','N','S',1,320,2,'N','8','S','S','S','S','S','S');

/*MENU SECURITY*/
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCSecurity',1,'Cadastro','EMCSecurity',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCSecurity',101,'Usuário','EMCSecurity','frmUsuario',NULL,'N','N','S',1,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCSecurity',105,'Aplicação','EMCSecurity','frmAplicacao',NULL,'N','N','S',2,1,1,'S','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCSecurity',108,'Aplicação','EMCSecurity','frmUsuarioAplicacao',NULL,'N','N','S',2,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCSecurity',110,'Menu Sistema','EMCSecurity','frmMenuSistema',NULL,'N','N','S',3,1,1,'S','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCSecurity',115,'Menu Usuário','EMCSecurity','frmMenuUsuario',NULL,'N','N','S',4,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCSecurity',120,'Usuário Empresa','EMCSecurity','frmUsuarioEmpresa',NULL,'N','N','S',5,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCSecurity',130,'Parematros Sistema','EMCSecurity','frmParametros',NULL,'N','N','S',5,1,1,'N','8','S','S','S','S','S','S');


/*MENU FINANCEIRO*/
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 1,'Contas a Pagar','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 2,'Contas a Receber','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 3,'Controle Bancário','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 4,'Controle de Caixa','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 5,'Cheques/Recibos','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 6,'Relatórios','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 7,'Processamento','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');

INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 105,'Documento a Pagar','EMCFinanceiro','frmPagarDocumento',NULL,'N','N','S',1,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 998,'Pagar Base Rateio','EMCFinanceiro','frmPagarBaseRateio',NULL,'N','N','S',1,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 110,'Liberação Pagamento','EMCFinanceiro','frmPagarLiberacao',NULL,'N','N','S',2,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 115,'Baixa Documentos','EMCFinanceiro','frmPagarBaixa',NULL,'N','N','S',3,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 120,'Fatura Pagar','EMCFinanceiro','frmPagarFatura',NULL,'N','N','S',4,1,1,'N','8','S','S','S','S','S','S');

INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCFinanceiro', 205,'Formulários','EMCFinanceiro','frmReceberFormulario',NULL,'N','N','S',1,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCFinanceiro', 210,'Documento a Receber','EMCFinanceiro','frmReceberDocumento',NULL,'N','N','S',2,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCFinanceiro', 213,'Acordo Financeiro','EMCFinanceiro','frmReceberAcordo',NULL,'N','N','S',3,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCFinanceiro', 215,'Baixa Documentos','EMCFinanceiro','frmReceberBaixa',NULL,'N','N','S',3,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 997,'Receber Base Rateio','EMCFinanceiro','frmReceberBaseRateio',NULL,'N','N','S',1,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 220,'Fatura Receber','EMCFinanceiro','frmReceberFatura',NULL,'N','N','S',4,2,1,'N','8','S','S','S','S','S','S');

INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 999,'Movimentação Bancaria','EMCFinanceiro','frmMovimentoBancario',NULL,'N','N','S',1,3,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 305,'Movimentação Bancaria','EMCFinanceiro','frmGrdMovBancario',NULL,'N','N','S',1,3,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao` ) 
VALUES (1, 'EMCFinanceiro', 310,'Tarifas Bancarias','EMCFinanceiro','frmTarifasBancarias',NULL,'N','N','S',2,3,1,'N','8','S','S','S','S','S','S');

INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenusistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 400,'Abertura Caixa','EMCFinanceiro','frmAbreCaixa',NULL,'N','N','S',1,4,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 410,'Fechamento de Caixa','EMCFinanceiro','frmFechaCaixa',NULL,'N','N','S',2,4,1,"N",'8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 420,'Conferência de Caixa','EMCFinanceiro','frmConfereCaixa',NULL,'N','N','S',3,4,1,"N",'8','S','S','S','S','S','S');

INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 500,'Emissão de Cheques','EMCFinanceiro','frmEmissaoCheques',NULL,'N','N','S',1,5,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 505,'Emissão de Recibos','EMCFinanceiro','frmEmissaoRecibos',NULL,'N','N','S',2,5,1,'N','8','S','S','S','S','S','S');

INSERT INTO `menusistema` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 600,'Contas a Pagar','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 60005,'Contas Pagas','EMCFinanceiro','relCtasPagarBaixa',NULL,'N','N','S',1,600,2,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 60010,'Contas a Pagar','EMCFinanceiro','relCtasPagar',NULL,'N','N','S',2,600,2,'N','8','S','S','S','S','S','S');

INSERT INTO `menusistema` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 610,'Contas a Receber','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 61005,'Contas Recebidas','EMCFinanceiro','relCtasRecebidas',NULL,'N','N','S',1,610,2,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 61010,'Contas a Receber','EMCFinanceiro','relCtasReceber',NULL,'N','N','S',2,610,2,'N','8','S','S','S','S','S','S');

INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 620,'Controle Bancario','EMCFinanceiro',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 62005,'Cheques Emitidos','EMCFinanceiro','relChequeEmitidos',NULL,'N','N','S',1,610,2,'N','8','S','S','S','S','S','S');

/* Processaemnto */
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCFinanceiro', 700,'Integracao Documentos','EMCFinanceiro','frmIntegracao',NULL,'N','N','S',1,7,1,'N','8','S','S','N','N','N','N');



/*MENU LOCACAO***********************************************************************************************************************************/
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCImob',1,'Cadastros','EMCImob',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCImob',110,'Comodo','EMCImob','frmComodo',NULL,'N','N','S',1,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCImob',115,'Tipo Imóvel','EMCImob','frmTipoImovel',NULL,'N','N','S',2,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCImob',120,'Carteira Imovel','EMCImob','frmCarteiraImoveis',NULL,'N','N','S',3,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCImob',125,'Tipo Lançamento Captação','EMCImob','frmTipoLanctoCaptacao',NULL,'N','N','S',4,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCImob',130,'Proventos','EMCImob','frmLocacaoProventos',NULL,'N','N','S',5,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCImob',135,'Imóvel','EMCImob','frmImovel',NULL,'N','N','S',6,1,1,'N','8','S','S','S','S','S','S');

INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCImob',2,'Movimento','EMCImob',NULL,NULL,'N','N','N',1,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCImob',200,'Captação Vendedor','EMCImob','frmContasCaptacao',NULL,'N','N','S',1,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCImob',205,'Despesa Imovel','EMCImob','frmDespesaImovel',NULL,'N','N','S',2,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCImob',210,'Captação Vendedor','EMCImob','frmIPTU',NULL,'N','N','S',3,2,1,'N','8','S','S','S','S','S','S');

INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCImob',3,'Locação Imoveis','EMCImob',NULL,NULL,'N','N','N',3,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCImob',300,'Contrato Locação Imovel','EMCImob','frmContratoLocacao',NULL,'N','N','S',1,3,1,'N','8','S','S','S','S','S','S');

INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`,`exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1, 'EMCImob',4,'Relatorios','EMCImob',NULL,NULL,'N','N','N',4,0,0,'N','8','S','S','S','S','S','S');




/*Menu Faturamento*********************************************************************************************************************************/
/* Menu Geral*/
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCFaturamento', 1,'Notas Fiscais','EMCFaturamento',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCFaturamento', 2,'Tabelas','EMCFaturamento',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCFaturamento', 3,'Relatórios','EMCFaturamento',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
/* Menu Notas Fiscais */

/* Menu Tabelas */
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCFaturamento', 205,'Código Fiscal - CFOP','EMCFaturamento','frmFatu_CFOP',NULL,'N','N','S',1,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCFaturamento', 210,'Nomenclatura Comum do Mercosul - NCM','EMCFaturamento','frmFatu_NCM',NULL,'N','N','S',2,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCFaturamento', 215,'Origem Mercadoria','EMCFaturamento','frmFatu_OrigemMercadoria',NULL,'N','N','S',3,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCFaturamento', 220,'Situação Fiscal IPI','EMCFaturamento','frmFatu_SituacaoFiscalIPI',NULL,'N','N','S',4,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`)  
VALUES (1,'EMCFaturamento', 221,'Situação Fiscal Cofins','EMCFaturamento','frmFatu_SituacaoCofins',NULL,'N','N','S',4,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`)  
VALUES (1,'EMCFaturamento', 222,'Situação Fiscal PIS','EMCFaturamento','frmFatu_SituacaoPis',NULL,'N','N','S',4,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`)  
VALUES (1,'EMCFaturamento', 223,'Motivo ICMS','EMCFaturamento','frmFatu_MotivoIcms',NULL,'N','N','S',4,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCFaturamento', 225,'Regime Tributação','EMCFaturamento','frmFatu_Tributacao',NULL,'N','N','S',5,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCFaturamento', 227,'Regime Tributação IPI','EMCFaturamento','frmFatu_TributacaoIPI',NULL,'N','N','S',5,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCFaturamento', 230,'Natureza de Operação','EMCFaturamento','frmFatu_NaturezaOperacao',NULL,'N','N','S',6,2,1,'N','8','S','S','S','S','S','S');

/* SISTEM DE OBRAS */
/* Menu Geral*/
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCObras', 1,'Tabelas','EMCObras',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCObras', 2,'Movimentos','EMCObras',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`,`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCObras', 3,'Relatórios','EMCObras',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');

/* Menu Tabelas */
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCObras', 105,'Etapa','EMCObras','frmObra_Etapa',NULL,'N','N','S',1,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCObras', 110,'Módulo','EMCObras','frmObra_Modulo',NULL,'N','N','S',2,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCObras', 115,'Tarefa','EMCObras','frmObra_Tarefa',NULL,'N','N','S',3,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`,`modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCObras', 120,'Tipo Contrato - OBras','EMCObras','frmObra_TipoContrato',NULL,'N','N','S',4,1,1,'N','8','S','S','S','S','S','S');
/* Menu Movimentação */
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCObras', 205,'Obra','EMCObras','frmObra',NULL,'N','N','S',1,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCObras', 210,'Cronograma de Obra','EMCObras','frmCronograma',NULL,'N','N','S',2,2,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCObras', 215,'Previsão Despesas','EMCObras','frmPrevisaoDespesa',NULL,'N','N','S',3,2,1,'N','8','S','S','S','S','S','S');

/* Controle de Estoque */
/* Menu Geral*/
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCEstoque', 1,'Cadastros','EMCEstoque',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCEstoque', 2,'Movimentos','EMCEstoque',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCEstoque', 3,'Relatórios','EMCEstoque',NULL,NULL,'N','N','N',0,0,0,'N','8','S','S','S','S','S','S');
/* Menu Cadastros */
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCEstoque', 105,'Almoxarifado','EMCEstoque','frmEstq_Almoxarifado',NULL,'N','N','S',1,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCEstoque', 110,'Familia Produto','EMCEstoque','frmEstq_Familia',NULL,'N','N','S',2,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCEstoque', 115,'Grupo Produto','EMCEstoque','frmEstq_Grupo',NULL,'N','N','S',3,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCEstoque', 116,'SubGrupo Produto','EMCEstoque','frmEstq_SubGrupo',NULL,'N','N','S',4,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCEstoque', 120,'Tipo Produto','EMCEstoque','frmEstq_TipoProduto',NULL,'N','N','S',5,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCEstoque', 125,'Unidade','EMCEstoque','frmEstq_Produto_Unidade',NULL,'N','N','S',6,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCEstoque', 126,'Embalagem','EMCEstoque','frmEstq_Embalagem',NULL,'N','N','S',7,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCEstoque', 130,'Produto','EMCEstoque','frmEstq_Produto',NULL,'N','N','S',10,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCEstoque', 999,'Produto [Descrição]','EMCEstoque','frmEstq_Descricao',NULL,'N','N','S',1,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCEstoque', 998,'Produto [Fornecedor]','EMCEstoque','frmEstq_Produto_Fornecedor',NULL,'N','N','S',1,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCEstoque', 997,'Produto [Lote]','EMCEstoque','frmEstq_Produto_Lote',NULL,'N','N','S',1,1,1,'N','8','S','S','S','S','S','S');
INSERT INTO `menuusuario` (`idusuario`, `modulo`,`idmenuSistema`,`descricao`,`namespace`,`endereco`,`urlimagem`,`exibeimagem`,`itemseguranca`,`indicadorabertura`,`Ordem`,`menupai`,`nivel`, `exclusivojlm`, `nivelusuario`, `executa`, `inclusao`, `alteracao`, `exclusao`, `ocorrencia`, `impressao`) 
VALUES (1,'EMCEstoque', 996,'Produto [Volume]','EMCEstoque','frmEstq_Produto_Volume',NULL,'N','N','S',1,1,1,'N','8','S','S','S','S','S','S');
