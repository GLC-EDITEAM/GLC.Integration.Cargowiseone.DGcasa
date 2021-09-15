namespace GLC.Integration.Cargowiseone.DGcasa.outbound945 {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment", typeof(global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CargowiseOne.CLASSICBRANDS.Schemas.EDI945.X12_00401_945", typeof(global::GLC.Integration.CargowiseOne.CLASSICBRANDS.Schemas.EDI945.X12_00401_945))]
    public sealed class TransformDGCasaShipmentToEDI945 : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s0 userCSharp"" version=""1.0"" xmlns:ns0=""http://schemas.microsoft.com/BizTalk/EDI/X12/2006"" xmlns:s0=""http://www.cargowise.com/Schemas/Universal/2011/11"" xmlns:userCSharp=""http://schemas.microsoft.com/BizTalk/2003/userCSharp"" xmlns:ScriptNS0=""http://schemas.microsoft.com/BizTalk/2003/ScriptNS0"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s0:UniversalShipment"" />
  </xsl:template>
  <xsl:template match=""/s0:UniversalShipment"">
    <xsl:variable name=""var:v3"" select=""userCSharp:StringConcat(&quot;CL&quot;)"" />
    <xsl:variable name=""var:v4"" select=""userCSharp:StringConcat(&quot;WH&quot;)"" />
    <xsl:variable name=""var:v5"" select=""userCSharp:StringConcat(&quot;DGCASA c/o GLC&quot;)"" />
    <ns0:X12_00401_945>
      <ns0:W06>
        <W0602>
          <xsl:value-of select=""s0:Shipment/s0:Order/s0:ClientReference/text()"" />
        </W0602>
        <!--<xsl:for-each select=""s0:Shipment/s0:DataContext"">
          <xsl:for-each select=""s0:EventType"">
            <xsl:variable name=""var:v1"" select=""userCSharp:LogicalEq(string(s0:Code/text()) , &quot;FIN&quot;)"" />
            <xsl:if test=""string($var:v1)='true'"">-->
              <xsl:variable name=""var:v2"" select=""userCSharp:Getdateformat(s0:Shipment/s0:DataContext/s0:TriggerDate/text())"" />
              <W0603>
                <xsl:value-of select=""$var:v2"" />
              </W0603>
            <!--</xsl:if>
          </xsl:for-each>
        </xsl:for-each>-->
        <W0605>
          <xsl:value-of select=""s0:Shipment/s0:Order/s0:OrderNumber/text()"" />
        </W0605>
        <W0611>
          <xsl:value-of select=""$var:v3"" />
        </W0611>
      </ns0:W06>
      <ns0:N1Loop1>
        <ns0:N1>
          <N101>
            <xsl:value-of select=""$var:v4"" />
          </N101>
          <N102>
            <xsl:value-of select=""$var:v5"" />
          </N102>
        </ns0:N1>
        <ns0:N3>
          <N301>9724 Alabama st</N301>
        </ns0:N3>
        <ns0:N4>
          <N401>Redlands</N401>
          <N402>CA</N402>
          <N403>92374</N403>
          <N404>US</N404>
        </ns0:N4>
      </ns0:N1Loop1>
      <xsl:for-each select=""s0:Shipment/s0:OrganizationAddressCollection/s0:OrganizationAddress"">
        <xsl:if test=""s0:AddressType/text()='ConsigneeAddress'"">
          <ns0:N1Loop1>
            <ns0:N1>
              <N101>
                <xsl:text>ST</xsl:text>
              </N101>
              <N102>
                <xsl:value-of select=""s0:CompanyName/text()"" />
              </N102>
              </ns0:N1>
            <ns0:N3>
              <N301>
                <xsl:value-of select=""s0:Address1/text()""/>
              </N301>
              <N302>
                <xsl:value-of select=""s0:Address2/text()""/>
              </N302>
            </ns0:N3>
            <ns0:N4>
              <N401>
                <xsl:value-of select=""s0:City/text()""/>
              </N401>
              <N402>
                <xsl:value-of select=""s0:State/text()""/>
              </N402>
              <N403>
                <xsl:value-of select=""s0:Postcode/text()""/>
              </N403>
              <N404>
                <xsl:value-of select=""s0:Country/s0:Code/text()""/>
              </N404>
            </ns0:N4>

          </ns0:N1Loop1>

        </xsl:if>
      </xsl:for-each>

      <ns0:N9>
        <N901>
          <xsl:text>BM</xsl:text>
        </N901>
        <N902>
          <xsl:value-of select=""s0:Shipment/s0:Order/s0:TransportReference/text()""/>
        </N902>
      </ns0:N9>

      <xsl:variable name=""varDeliverdate"" select=""s0:Shipment/s0:LocalProcessing/s0:DeliveryRequiredBy/text()""/>
      <!--<xsl:for-each select=""s0:Shipment/s0:MilestoneCollection/s0:Milestone"">-->

        <!--<xsl:if test=""s0:EventCode/text()='FIN'"">-->
          <ns0:G62>
            <G6201>
              <xsl:text>11</xsl:text>
            </G6201>
            <xsl:variable name=""vartrigger"" select=""userCSharp:Getdateformat(s0:Shipment/s0:DataContext/s0:TriggerDate/text())"" />
            <G6202>
              <xsl:value-of select=""$vartrigger""/>
            </G6202>

          </ns0:G62>
        <!--</xsl:if>-->

      <!--</xsl:for-each>-->

      <xsl:for-each select=""s0:Shipment/s0:OrganizationAddressCollection/s0:OrganizationAddress"">
        <xsl:if test=""s0:AddressType/text()='TransportCompanyDocumentaryAddress'"">
          <ns0:W27>
            <W2701>
              <xsl:text>M</xsl:text>
            </W2701>
            <W2702>
              <xsl:value-of select=""s0:CompanyName/text()"" />
            </W2702>            
          </ns0:W27>
        </xsl:if>
      </xsl:for-each>

      <xsl:for-each select=""s0:Shipment/s0:Order/s0:OrderLineCollection/s0:OrderLine"">
        <xsl:variable name=""varprodcodelist"" select =""s0:Product/s0:Code/text()""/>
        <xsl:variable name=""varproddesc"" select =""s0:Product/s0:Description/text()""/>

        <ns0:LXLoop1>
          <ns0:LX>
            <LX01>
              <xsl:value-of select=""s0:LineNumber/text()""/>
            </LX01>
          </ns0:LX>

         <ns0:MAN>
           <MAN01>EA</MAN01>
         
         <!--<xsl:for-each select=""s0:CustomizedFieldCollection/s0:CustomizedField"">
                <xsl:if test=""s0:Key/text()='TRACKINGNO'""> -->
                  <MAN02>
                    <!--<xsl:value-of select=""s0:Value/text()""/>-->
                    <xsl:value-of select=""s0:LineComment/text()""/>
                  </MAN02>
             <!-- </xsl:if>
              </xsl:for-each>-->
          </ns0:MAN>


          <ns0:W12Loop1>
            <ns0:W12>
              <W1201>
                <xsl:text>CC</xsl:text>
              </W1201>
              <W1202>
                <xsl:value-of select=""s0:OrderedQty/text()""/>
              </W1202>
              <!--<xsl:variable name=""varw1203"" select=""ScriptNS0:Get945convPCE(s0:Product/s0:Code/text(),userCSharp:replacefunc(s0:OrderedQty/text()))""/>-->
              <W1203>
                <xsl:value-of select=""s0:QuantityMet/text()""/>
              </W1203>
              <W1204>
                <xsl:value-of select =""s0:ShortfallQuantity/text()""/>
              </W1204>
              <W1205>EA</W1205>
              <!--<xsl:if test=""s0:CustomizedFieldCollection/s0:CustomizedField/s0:Key/text()='UPC CODE'"">
                <W1206>
                  <xsl:value-of select=""s0:CustomizedFieldCollection/s0:CustomizedField/s0:Value/text()""/>
                </W1206>
              </xsl:if>-->
              <W1207>
                <xsl:text>IT</xsl:text>
              </W1207>
              <W1208>
                <xsl:value-of select=""s0:Product/s0:Code/text()""/>
              </W1208>
              <!--<W1211>
                <xsl:text>TR</xsl:text>
              </W1211>-->
                <!--<xsl:for-each select=""s0:CustomizedFieldCollection/s0:CustomizedField"">
                <xsl:if test=""s0:Key/text()='TRACKINGNO'"">
                  <W1212>
                    <xsl:value-of select=""s0:Value/text()""/>
                  </W1212>
              </xsl:if>
              </xsl:for-each>-->
              <W1215>VN</W1215>
              <xsl:for-each select=""s0:CustomizedFieldCollection/s0:CustomizedField"">
                <xsl:if test=""s0:Key/text()='NETSUITEIDVN'"">
                  <W1216>
                    <xsl:value-of select=""s0:Value/text()""/>
                  </W1216>
                </xsl:if>
              </xsl:for-each>
            </ns0:W12>

          </ns0:W12Loop1>

        </ns0:LXLoop1>
      </xsl:for-each>

      <ns0:W03>
        <W0301>
          <xsl:value-of select=""s0:Shipment/s0:Order/s0:TotalUnits/text()""/>
        </W0301>
      </ns0:W03>

    </ns0:X12_00401_945>
  </xsl:template>
  <msxsl:script language=""C#"" implements-prefix=""userCSharp"">
    <![CDATA[
    
    public string getproddesc(string strin)
    {
        int a = 0;
            if (strin.Contains(""-- EXP""))
            {
                a = strin.Length - 18;
            }
            else
            {
                a = strin.Length;
            }

            string strout = strin.Substring(0, a);
        return strout;
       }
    
    public int getdiff(int a1,int a2)
    {
         int a11=a1-a2;
         return a11;
    }
    
    public string replacefunc(string strin)
    {
    strin=strin.Replace("".000"","""");
    return strin;
    }    
    public string Getdateformat(string strin)
    {
           DateTime dt2 = new DateTime();
            dt2 = Convert.ToDateTime(strin);
            strin = dt2.ToString(""yyyyMMdd"");
            return strin;
    }
public bool LogicalEq(string val1, string val2)
{
	bool ret = false;
	double d1 = 0;
	double d2 = 0;
	if (IsNumeric(val1, ref d1) && IsNumeric(val2, ref d2))
	{
		ret = d1 == d2;
	}
	else
	{
		ret = String.Compare(val1, val2, StringComparison.Ordinal) == 0;
	}
	return ret;
}


public string StringConcat(string param0)
{
   return param0;
}


public bool IsNumeric(string val)
{
	if (val == null)
	{
		return false;
	}
	double d = 0;
	return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);
}

public bool IsNumeric(string val, ref double d)
{
	if (val == null)
	{
		return false;
	}
	return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);
}


]]>
  </msxsl:script>
</xsl:stylesheet>";
        
        private const int _useXSLTransform = 0;
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment";
        
        private const global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"GLC.Integration.CargowiseOne.CLASSICBRANDS.Schemas.EDI945.X12_00401_945";
        
        private const global::GLC.Integration.CargowiseOne.CLASSICBRANDS.Schemas.EDI945.X12_00401_945 _trgSchemaTypeReference0 = null;
        
        public override string XmlContent {
            get {
                return _strMap;
            }
        }
        
        public override int UseXSLTransform {
            get {
                return _useXSLTransform;
            }
        }
        
        public override string XsltArgumentListContent {
            get {
                return _strArgList;
            }
        }
        
        public override string[] SourceSchemas {
            get {
                string[] _SrcSchemas = new string [1];
                _SrcSchemas[0] = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"GLC.Integration.CargowiseOne.CLASSICBRANDS.Schemas.EDI945.X12_00401_945";
                return _TrgSchemas;
            }
        }
    }
}
