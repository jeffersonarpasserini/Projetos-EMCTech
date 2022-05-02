/*
 Script inicialização de parametros do sistema
 */
/* EMCCadastro */
 insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
 values(1,"EMCCADASTRO","CTABANCARIA","OCORRENCIA_SALDO","C","S","GERA OCORRENCIAS PARA ALTERACÃO DE SALDO (S/N)");
 insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
 values(1,"EMCCADASTRO","CONTACUSTO","TAMANHO_CONTACUSTO","C","11","DEFINE O TAMANHO MÁXIMO DA CONTA CUSTO (MAXIMO 20 DIGITOS)");
 insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
 values(1,"EMCCADASTRO","CONTACUSTO","NRONIVEIS_CONTACUSTO","C","5","NUMERO DE NIVEIS CONTA CUSTO(MAXIMO 7 NIVEIS)");
 insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
 values(1,"EMCCADASTRO","CONTACUSTO","TAM_NV1_CONTACUSTO","C","1","DEFINE NRO DIGITOS DO NIVEL 1 DA CONTA CUSTO");
 insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
 values(1,"EMCCADASTRO","CONTACUSTO","TAM_NV2_CONTACUSTO","C","2","DEFINE NRO DIGITOS DO NIVEL 2 DA CONTA CUSTO");
 insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
 values(1,"EMCCADASTRO","CONTACUSTO","TAM_NV3_CONTACUSTO","C","2","DEFINE NRO DIGITOS DO NIVEL 3 DA CONTA CUSTO");
 insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
 values(1,"EMCCADASTRO","CONTACUSTO","TAM_NV4_CONTACUSTO","C","2","DEFINE NRO DIGITOS DO NIVEL 4 DA CONTA CUSTO");
 insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
 values(1,"EMCCADASTRO","CONTACUSTO","TAM_NV5_CONTACUSTO","C","4","DEFINE NRO DIGITOS DO NIVEL 5 DA CONTA CUSTO");
 insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
 values(1,"EMCCADASTRO","CONTACUSTO","TAM_NV6_CONTACUSTO","C","0","DEFINE NRO DIGITOS DO NIVEL 6 DA CONTA CUSTO");
 insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
 values(1,"EMCCADASTRO","CONTACUSTO","TAM_NV7_CONTACUSTO","C","0","DEFINE NRO DIGITOS DO NIVEL 7 DA CONTA CUSTO");
 
/* Financeiro  - CONTAS A PAGAR */
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","GERAL","UTILIZA_INDEXADOR","C","N","DEFINE SE O SISTEMA FINANCEIRO DEVE UTILIZAR INDEXADORES (N/S)");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","GERAL","MOEDA_CORRENTE","C","1","DEFINE O CODIGO DO INDEXADOR QUE É A MOEDA CORRENTE NO PAIS");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","CTAPAGAR","OBRIGA_LIBERACAO","C","S","DEFINE SE O SISTEMA DEVE EXIGIR LIBERACAO PARA PAGAMENTO NO CONTAS A PAGAR");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","CTAPAGAR","NUMERO_LIBERACAO","C","1","DEFINE O NUMERO DE AUTORIZADORES PARA LIBERAÇÃO DO CTA PAGAR PARA PAGAMENTO");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","CTAPAGAR","LANCTO_RETROATIVO","C","N","PERMITE LANCAMENTO RETROATIVO NA DIGITAÇÃO DO CONTAS A PAGAR");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","CTAPAGAR","VENCIMENTO_DIA_UTIL","C","S","DEFINE SE SOMENTE DIAS UTEIS PODEM SER VENCIMENTO DE PARCELAS");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","CTAPAGAR","TARIFA_DIGITA_CCUSTO","C","S","DEFINE SE O USUARIO VAI DIGITAR A CONTA CUSTO DAS TARIFAS BANCARIAS (S/N)");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","CTAPAGAR","TARIFA_CTACUSTO","C","","CODIGO CONTA CUSTO NÃO FOR DIGITAR NA TELA DE TARIFAS BANCARIAS");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","CTAPAGAR","TARIFA_CONCILIADA","C","S","GRAVA TARIFA BANCARIA NO MOVIMENTO JÁ CONCILIADO (S/N)");
 
/* Financeiro - CONTAS A RECEBER */
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","CTARECEBER","VENCIMENTO_DIA_UTIL","C","S","DEFINE SE SOMENTE DIAS UTEIS PODEM SER VENCIMENTO DE PARCELAS");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","CTARECEBER","LANCTO_RETROATIVO","C","N","PERMITE LANCAMENTO RETROATIVO NA DIGITAÇÃO DO CONTAS A RECEBER");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","CTARECEBER","TAXA_MULTA","N","10","PERCENTUAL DA MULTA A SER APLICADA AO CLIENTE EM ATRASO"); 
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","CTARECEBER","TAXA_JUROS","N","2","PERCENTUAL DE JUROS MENSAL A SER APLICADO AO CLIENTE EM ATRASO");  
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","CTARECEBER","TIPO_JUROS","C","C","TIPO DE JUROS APLICADO AO CLIENTE EM ATRASO - S-Simples ou C-Composto");  
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","CTARECEBER","ID_APROV_ACORDO01","N","C","ID DO USUARIO APROVADOR DE NEGOCIACAO DO CTA RECEBER");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","CTARECEBER","ID_APROV_ACORDO02","N","C","ID DO USUARIO APROVADOR DE NEGOCIACAO DO CTA RECEBER");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFINANCEIRO","CTARECEBER","ID_APROV_ACORDO03","N","C","ID DO USUARIO APROVADOR DE NEGOCIACAO DO CTA RECEBER");
 


 
/* Financeiro - MOVIMENTO BANCARIO */
 
 
/* Financeiro - CAIXA */

/* Integracao */
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCINTEGRACAO","LOCACAORECEBER","TIPODOCUMENTO","N","7","ID TIPO DOC INTEG. LOCACAO RECEBER");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCINTEGRACAO","LOCACAOPAGAR","TIPODOCUMENTO","N","7","ID TIPO DOC INTEG. LOCACAO PAGAR");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCINTEGRACAO","IPTU","TIPODOCUMENTO","N","26","ID TIPO DOC INTEG. CARNE IPTU");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCINTEGRACAO","DESPESAIMOVEL","TIPODOCUMENTO","N","1","ID TIPO DOC INTEG. DESPESA IMOVEL ");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCINTEGRACAO","CAPITACAO","TIPODOCUMENTO","N","9","ID TIPO DOC INTEG. CAPITACAO");

insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCINTEGRACAO","LOCACAORECEBER","APLICACAO","N","265","ID TIPO DOC INTEG. LOCACAO RECEBER");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCINTEGRACAO","LOCACAOPAGAR","APLICACAO","N","264","ID TIPO DOC INTEG. LOCACAO PAGAR");


 
/* Estoque */
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCESTOQUE","PRODUTO","UTILIZA_LOTE","C","N","DEFINE SE A EMPRESA VAI TER CONTROLE DE LOTES NO CADASTRO DE PRODUTOS");

/* Security */
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCSECURITY","BANCODADOS","SCHEMA","C","secol","DEFINE O NOME DO SCHEMA DE BANCO DADOS UTILIZADO");

/* Faturamento */
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCFATURAMENTO","DISPFISCAL","SCHEMA","C","M","DISP.FISCAL M-EMP.MASTER OU E-EMPRESA");

/* Obras */
 insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCOBRAS","OBRA","NRO_APROVADORES","C","3","NRO DE APROVADORES DE OBRA");
 insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCOBRAS","OBRA","USUARIO_APROVADOR01","C","1","ID USUARIO APROVADOR 01");
 insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCOBRAS","OBRA","USUARIO_APROVADOR02","C","2","ID USUARIO APROVADOR 02");
 insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCOBRAS","OBRA","USUARIO_APROVADOR03","C","5","ID USUARIO APROVADOR 03");


/* Contabil */
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCCONTABIL","VALIDACAO","TRAVADIGITACAO","C","S","TRAVA DIGITAÇÃO SE LANCAMENTO IGUAL OU ANTERIOR AO FECHAMENTO? S OU N");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCCONTABIL","VALIDACAO","PROCESSO_CONTABIL","C","31/12/2030","DATA ULTIMO PROCESSO CONTABIL (FORMATO DD/MM/YYYY)");

/* imob */
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCIMOB","PROVENTO","ALUG_LOCADOR","C","2","CODIGO PROVENTRO PARA ALUGUEL LOCADOR");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCIMOB","PROVENTO","ALUG_LOCATARIO","C","1","CODIGO PROVENTO PARA ALUGUEL LOCATARIO");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCIMOB","PROVENTO","COND_LOCATARIO","C","1","CODIGO PROVENTO PARA CONDOMINIO LOCATARIO");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCIMOB","PROVENTO","TAXA_ADM","C","3","CODIGO PROVENTO TXA ADM");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCIMOB","PROVENTO","DESC_CONC_LOCADOR","C","8","CODIGO PROVENTO DESC CONCEDIDO LOCADOR");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCIMOB","PROVENTO","DESC_CONC_LOCATARIO","C","9","CODIGO PROVENTO DESC CONCEDIDO LOCATARIO");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCIMOB","PROVENTO","BASE_DIMOB","C","4","CODIGO PROVENTO BASE DIMOB");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCIMOB","PROVENTO","JUROS_RECEBIDOS","C","5","CODIGO PROVENTO JUROS RECEBIDOS");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCIMOB","PROVENTO","JUROS_PAGOS","C","6","CODIGO PROVENTO JUROS PAGOS");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCIMOB","PROVENTO","JUROS_RETIDOS","C","7","CODIGO PROVENTO JUROS RETIDOS");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCIMOB","PROVENTO","BASE_IR","C","10","CODIGO PROVENTO BASE IMP. RENDA");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCIMOB","PROVENTO","IMPOSTO_RENDA","C","11","CODIGO PROVENTO VALOR IMPOSTO RENDA");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCIMOB","TAXA","TAXA_MULTA","C","10","PERCENTUAL MULTA ALUGUEL");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCIMOB","TAXA","TAXA_JUROS","C","2","PERCENTUAL JUROS ALUGUEL");
insert into parametro(codempresa,aplicacao,sessao,chave,tipo,valor,descricao)
values(1,"EMCIMOB","TAXA","PERC_TAXA_ADM","C","2","PERCENTUAL TAXA ADM");